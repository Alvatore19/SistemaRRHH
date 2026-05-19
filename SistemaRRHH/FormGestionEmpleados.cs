using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FormGestionEmpleados : Form
    {

        AN_Jerarquia miEmpresa = new AN_Jerarquia();

        string rolUsuarioActual;
        string idUsuarioActual;
        private int proximoIdNumerico;
        private Size tamañoArbolCache = Size.Empty;   

        // Variables para el zoom
        private float factorZoom = 1.0f;
        private const float ZOOM_MIN = 0.3f;
        private const float ZOOM_MAX = 2.5f;
        private const float ZOOM_STEP = 0.1f;
        private PointF puntoCentroZoom = PointF.Empty;

        public FormGestionEmpleados(string nivelUsuario, string idEmpleadoLogueado)
        {
            InitializeComponent();

            this.AutoScroll = true;

            InicializarContador();

            idUsuarioActual = idEmpleadoLogueado;
            rolUsuarioActual = (nivelUsuario == "1") ? "Director General" : "Analista de RRHH";

            // Eventos y configuración de controles
            panelArbol.Paint += panelArbol_Paint;
            panelStats.Paint += panelStats_Paint;
            btnEliminar.Enabled = false;
            cmbNuevoJefe.Enabled = false;

            panelArbol.Resize += panelArbol_Resize;
            panelArbol.AutoScroll = true;
            panelArbol.MouseWheel += PanelArbol_MouseWheel;
            ActualizarLabelZoom();

            txtActualizarNombre.Enabled = false;
            cmbActualizarCargo.Enabled = false;
            cmbActualizarJefe.Enabled = false;
            btnActualizar.Enabled = false;

            CargarDepartamentos();

            txtDui.MaxLength = 10;
            txtDui.KeyPress += txtDui_KeyPress;

            // Configurar buscadores inteligentes
            cmbActualizarSeleccion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbActualizarSeleccion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEliminar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEliminar.AutoCompleteSource = AutoCompleteSource.ListItems;

            // === CONFIGURACIÓN DE INTERFAZ SEGÚN ROL ===
            if (rolUsuarioActual != "Director General") // Es Analista
            {
                tabControlVistas.TabPages.Remove(tabAprobaciones);
                btnEliminar.Text = "Solicitar Despido (Requiere Aprobación)";
                btnEliminar.BackColor = Color.DarkOrange;
            }

            // Cargar empleados 
            CargarEmpleadosDesdeBD();

            // Activar doble buffer para reducir parpadeos
            panelArbol.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(panelArbol, true);
            panelStats.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(panelStats, true);
        }

        private void cmbActualizarCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActualizarCargo.SelectedIndex != -1 && cmbActualizarCargo.SelectedItem is Cargo cargoBD)
            {
                cmbEscalaSalarial.Items.Clear();
                cmbEscalaSalarial.Items.Add($"Salario Base (${cargoBD.SalarioBase})");
                cmbEscalaSalarial.Items.Add($"Escala 1 (${cargoBD.BonoEscala1})");
                cmbEscalaSalarial.Items.Add($"Escala 2 (${cargoBD.BonoEscala2})");
                cmbEscalaSalarial.Items.Add($"Escala 3 (${cargoBD.BonoEscala3})");
                cmbEscalaSalarial.SelectedIndex = 0;
            }
        }

        private void panelArbol_Resize(object sender, EventArgs e)
        {
            panelArbol.Invalidate(); 
        }

        private void InicializarContador()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    int maxNum = db.Empleado
                        .Where(e => e.IdEmpleado.StartsWith("EMP-"))
                        .Select(e => e.IdEmpleado)
                        .AsEnumerable()          
                        .Select(id => int.TryParse(id.Substring(4), out int num) ? num : 0)
                        .DefaultIfEmpty(0)
                        .Max();

                    proximoIdNumerico = maxNum + 1;
                }
            }
            catch
            {
                proximoIdNumerico = 1;
            }
        }

        // ==========================================
        // LÓGICA DE DEPARTAMENTOS Y CARGOS
        // ==========================================
        private void CargarDepartamentos()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    // 1. Llenamos el de crear empleado
                    var deptos1 = db.Departamento.ToList();
                    cmbDepartamento.DisplayMember = "NombreDepartamento"; // <-- PRIMERO ESTO
                    cmbDepartamento.ValueMember = "IdDepartamento";       // <-- LUEGO ESTO
                    cmbDepartamento.DataSource = deptos1;                 // <-- AL FINAL EL DATASOURCE
                    cmbDepartamento.SelectedIndex = -1;

                    // 2. Llenamos el de actualizar empleado
                    var deptos2 = db.Departamento.ToList();
                    cmbActualizarDepartamento.DisplayMember = "NombreDepartamento"; // <-- PRIMERO ESTO
                    cmbActualizarDepartamento.ValueMember = "IdDepartamento";       // <-- LUEGO ESTO
                    cmbActualizarDepartamento.DataSource = deptos2;                 // <-- AL FINAL EL DATASOURCE
                    cmbActualizarDepartamento.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar departamentos: " + ex.Message);
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // El "is int" es el escudo que evita el InvalidCastException
            if (cmbDepartamento.SelectedIndex != -1 && cmbDepartamento.SelectedValue is int)
            {
                int idDeptoSeleccionado = (int)cmbDepartamento.SelectedValue;
                try
                {
                    using (var db = new SistemaRRHHEntities2())
                    {
                        var cargosFiltrados = db.Cargo.Where(c => c.IdDepartamento == idDeptoSeleccionado).ToList();
                        cmbCargo.DisplayMember = "NombreRol";
                        cmbCargo.ValueMember = "IdCargo";
                        cmbCargo.DataSource = cargosFiltrados;
                        cmbCargo.SelectedIndex = -1;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                cmbCargo.DataSource = null;
            }
        }

        private void RefrescarUIArbol(bool forzarRedibujo = true)
        {
            List<NodoEmpleado> todos = miEmpresa.ObtenerTodosLosNodos();
            ActualizarComboBoxes(todos);
            CargarDirectorioDataGrid(todos);
            if (rolUsuarioActual == "Director General")
                CargarAprobacionesDataGrid();

            if (forzarRedibujo)
            {
                RecalcularTamañoArbol();   
                panelArbol.Invalidate();
                panelStats.Invalidate();
            }
        }

        // --- MÉTODOS PARA LLENAR LOS DATAGRIDVIEW ---
        private void CargarDirectorioDataGrid(List<NodoEmpleado> todosLosNodos)
        {
            // 1. Consultar la base de datos para obtener la verdad absoluta de los departamentos
            Dictionary<string, string> deptosReales = new Dictionary<string, string>();
            using (var db = new SistemaRRHHEntities2())
            {
                // Traemos los empleados con sus cargos y departamentos actualizados
                var empBD = db.Empleado.Include("Cargo.Departamento").ToList();
                foreach (var e in empBD)
                {
                    deptosReales[e.IdEmpleado] = (e.Cargo != null && e.Cargo.Departamento != null)
                                                 ? e.Cargo.Departamento.NombreDepartamento
                                                 : "N/A";
                }
            }

            // 2. Unir la información del árbol con el departamento real de la BD
            var directorio = todosLosNodos.Select(emp => new
            {
                Código = emp.Id,
                Nombre = emp.Nombre,
                DUI = emp.Dui,
                Cargo = emp.Puesto,
                Departamento = deptosReales.ContainsKey(emp.Id) ? deptosReales[emp.Id] : "N/A", // <-- Aquí extrae el Depto
                Jefe_Inmediato = emp.Jefe != null ? emp.Jefe.Nombre : "N/A (Cúspide)",
                Sueldo = emp.Sueldo
            }).ToList();

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = directorio;
        }

        private void CargarEmpleadosDesdeBD()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var empleadosBD = db.Empleado
                        .Include("Cargo")
                        .Where(e => e.EstadoActivo == true)
                        .ToList(); 

                    // Diccionario temporal para búsqueda O(1) - SOLO DURANTE LA CARGA
                    var nodosDict = new Dictionary<string, NodoEmpleado>();

                    // Paso 1: Crear todos los nodos sin enlazar
                    // Paso 1: Crear todos los nodos sin enlazar
                    foreach (var emp in empleadosBD)
                    {
                        var nodo = new NodoEmpleado(
                            emp.IdEmpleado,
                            emp.DocumentoLegal,
                            emp.NombreCompleto,
                            emp.Cargo.NombreRol,
                            emp.SalarioActual > 0 ? (double)emp.SalarioActual : (double)emp.Cargo.SalarioBase, emp.CorreoElectronico,
                            emp.Contrasena
                        );
                        nodosDict[emp.IdEmpleado] = nodo;
                    }

                    // Paso 2: Enlazar cada nodo con su jefe (usando el diccionario)
                    NodoEmpleado raiz = null;
                    foreach (var emp in empleadosBD)
                    {
                        NodoEmpleado nodoActual = nodosDict[emp.IdEmpleado];
                        if (string.IsNullOrEmpty(emp.IdJefe))
                        {
                            raiz = nodoActual;
                        }
                        else if (nodosDict.TryGetValue(emp.IdJefe, out NodoEmpleado jefe))
                        {
                            nodoActual.Jefe = jefe;
                            jefe.Subalternos.Add(nodoActual);
                        }
                    }

                    miEmpresa.Raiz = raiz;
                }

                RefrescarUIArbol(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la estructura organizacional: " + ex.Message);
            }
        }

        private int ObtenerSiguienteContador()
        {
            return proximoIdNumerico++;
        }

        private void CargarAprobacionesDataGrid()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var solicitudes = (from s in db.SolicitudDespido
                                       where s.EstadoAprobacion == "Pendiente"
                                       join emp in db.Empleado on s.IdEmpleadoADespedir equals emp.IdEmpleado
                                       join sol in db.Empleado on s.IdSolicitante equals sol.IdEmpleado
                                       select new
                                       {
                                           ID_Solicitud = s.IdSolicitud,
                                           Solicitante = sol.NombreCompleto,
                                           A_Despedir = emp.NombreCompleto,
                                           ID_Empleado = emp.IdEmpleado,
                                           Motivo_Despido = s.MotivoDespido,
                                           Fecha = s.FechaSolicitud,
                                           Nuevo_Jefe_ID = s.IdNuevoJefeAsignado
                                       }).ToList();

                    dgvSolicitudes.DataSource = solicitudes;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error al cargar aprobaciones: " + ex.Message); }
        }

        private void ActualizarComboBoxes(List<NodoEmpleado> todosLosNodos)
        {
            cmbJefe.DataSource = null;
            cmbJefe.DataSource = new List<NodoEmpleado>(todosLosNodos);
            cmbJefe.SelectedIndex = -1;

            cmbEliminar.DataSource = null;
            cmbEliminar.DataSource = new List<NodoEmpleado>(todosLosNodos);
            cmbEliminar.SelectedIndex = -1;

            cmbNuevoJefe.DataSource = null;
            cmbNuevoJefe.DataSource = new List<NodoEmpleado>(todosLosNodos);
            cmbNuevoJefe.SelectedIndex = -1;

            cmbActualizarSeleccion.DataSource = null;
            cmbActualizarSeleccion.DataSource = new List<NodoEmpleado>(todosLosNodos);
            cmbActualizarSeleccion.SelectedIndex = -1;

            cmbActualizarJefe.DataSource = null;
            cmbActualizarJefe.DataSource = new List<NodoEmpleado>(todosLosNodos);
            cmbActualizarJefe.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validación: Obligar a seleccionar un empleado
            if (cmbEliminar.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista antes de procesar el despido.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NodoEmpleado nodoAEliminar = (NodoEmpleado)cmbEliminar.SelectedItem;
            string motivo = txtMotivoDespido.Text.Trim();

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo para justificar el despido.", "Motivo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nodoAEliminar == miEmpresa.Raiz && nodoAEliminar.Subalternos.Count > 0)
            {
                MessageBox.Show("No puedes despedir al Director General activo.", "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string idNuevoJefe = null;
            if (nodoAEliminar.Subalternos.Count > 0)
            {
                if (cmbNuevoJefe.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione a quién se le asignará el equipo del empleado a despedir."); return;
                }
                NodoEmpleado nuevoJefe = (NodoEmpleado)cmbNuevoJefe.SelectedItem;
                if (nuevoJefe.Id == nodoAEliminar.Id)
                {
                    MessageBox.Show("El nuevo jefe no puede ser la persona que se está despidiendo."); return;
                }
                idNuevoJefe = nuevoJefe.Id;
            }

            // Aplicación de Try-Catch para base de datos
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    if (rolUsuarioActual == "Director General")
                    {
                        var empBD = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == nodoAEliminar.Id);
                        if (empBD != null)
                        {
                            var subalternosBD = db.Empleado.Where(emp => emp.IdJefe == nodoAEliminar.Id).ToList();
                            foreach (var sub in subalternosBD) sub.IdJefe = idNuevoJefe;

                            db.Empleado.Remove(empBD);
                            db.SaveChanges();
                        }

                        miEmpresa.EliminarConReasignacion(nodoAEliminar.Id, idNuevoJefe);
                        MessageBox.Show("Despido procesado inmediatamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var nuevaSolicitud = new SolicitudDespido
                        {
                            IdSolicitante = idUsuarioActual,
                            IdEmpleadoADespedir = nodoAEliminar.Id,
                            IdNuevoJefeAsignado = idNuevoJefe,
                            MotivoDespido = motivo,
                            EstadoAprobacion = "Pendiente",
                            FechaSolicitud = DateTime.Now
                        };

                        db.SolicitudDespido.Add(nuevaSolicitud);
                        db.SaveChanges();

                        MessageBox.Show("La solicitud de despido ha sido enviada al Director General para su revisión.", "Enviado a Dirección", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    txtMotivoDespido.Clear();
                    RefrescarUIArbol(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el despido en la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTONES DE LA BANDEJA DEL DIRECTOR GENERAL ---
        private void btnAprobarDespido_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila completa de la tabla para aprobar."); return;
            }

            int idSolicitud = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["ID_Solicitud"].Value);
            string idADespedir = dgvSolicitudes.SelectedRows[0].Cells["ID_Empleado"].Value.ToString();
            string idNuevoJefe = dgvSolicitudes.SelectedRows[0].Cells["Nuevo_Jefe_ID"].Value?.ToString();

            using (var db = new SistemaRRHHEntities2())
            {
                // 1. Efectuar despido en SQL
                var empBD = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == idADespedir);
                if (empBD != null)
                {
                    var subalternosBD = db.Empleado.Where(emp => emp.IdJefe == idADespedir).ToList();
                    foreach (var sub in subalternosBD) sub.IdJefe = idNuevoJefe;
                    db.Empleado.Remove(empBD);
                }

                // 2. Marcar solicitud como aprobada
                var solicitud = db.SolicitudDespido.Find(idSolicitud);
                if (solicitud != null) solicitud.EstadoAprobacion = "Aprobado";

                db.SaveChanges();
            }

            // 3. Actualizar memoria RAM y UI

            miEmpresa.EliminarConReasignacion(idADespedir, idNuevoJefe);

            MessageBox.Show("Despido Aprobado y Ejecutado.");
            RefrescarUIArbol(true);
        }

        private void btnRechazarDespido_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila completa de la tabla para denegar."); return;
            }

            string motivoRechazo = txtMotivoRechazo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivoRechazo))
            {
                MessageBox.Show("Debe escribir un motivo por el cual rechaza este despido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            int idSolicitud = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells["ID_Solicitud"].Value);

            using (var db = new SistemaRRHHEntities2())
            {
                var solicitud = db.SolicitudDespido.Find(idSolicitud);
                if (solicitud != null)
                {
                    solicitud.EstadoAprobacion = "Denegado";
                    solicitud.MotivoRechazo = motivoRechazo;
                    db.SaveChanges();
                }
            }

            MessageBox.Show("Solicitud denegada. El empleado mantiene su cargo.");
            txtMotivoRechazo.Clear();
            CargarAprobacionesDataGrid();
        }

        private void btnIngresarEmpleado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbCargo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDui.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDui.Text, @"^\d{8}-\d$"))
            {
                MessageBox.Show("El formato del DUI es incorrecto (Ejemplo: 12345678-9).", "DUI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDui.Focus(); return;
            }

            if (!txtUsername.Text.Contains("@") || !txtUsername.Text.Contains("."))
            {
                MessageBox.Show("El nombre de usuario debe ser un correo electrónico válido.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus(); return;
            }

            if (miEmpresa.Raiz != null && cmbJefe.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un jefe para el nuevo empleado.", "Jefe Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nuevoId = "EMP-" + ObtenerSiguienteContador();
                string correoIngresado = txtUsername.Text.Trim();
                Cargo cargoSeleccionado = (Cargo)cmbCargo.SelectedItem;
                string nombreCargo = cargoSeleccionado.NombreRol;
                int idCargoSQL = cargoSeleccionado.IdCargo;

                using (var db = new SistemaRRHHEntities2())
                {
                    if (db.Empleado.Any(emp => emp.DocumentoLegal == txtDui.Text))
                    {
                        MessageBox.Show("Este número de DUI ya se encuentra registrado.", "DUI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDui.Focus(); return;
                    }

                    if (db.Empleado.Any(emp => emp.CorreoElectronico == correoIngresado))
                    {
                        MessageBox.Show("Este correo ya está asignado a otro empleado.", "Correo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus(); return;
                    }

                    if (nombreCargo == "Director General")
                    {
                        int totalDirectores = db.Empleado.Count(emp => emp.IdCargo == idCargoSQL && emp.EstadoActivo == true);
                        if (totalDirectores >= 1)
                        {
                            MessageBox.Show("La empresa ya cuenta con un Director General. Solo se permite 1 en toda la organización.", "Límite Jerárquico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else if (nombreCargo == "Analista de RRHH")
                    {
                        int totalAnalistas = db.Empleado.Count(emp => emp.IdCargo == idCargoSQL && emp.EstadoActivo == true);
                        if (totalAnalistas >= 3)
                        {
                            MessageBox.Show("Se ha alcanzado el límite máximo de 3 Analistas de Recursos Humanos.", "Límite de Personal", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string idJefeSQL = null;
                    string nombreJefePasaMetodo = "N/A (Director General)";

                    if (cmbJefe.SelectedIndex != -1)
                    {
                        NodoEmpleado jefeSeleccionado = (NodoEmpleado)cmbJefe.SelectedItem;
                        idJefeSQL = jefeSeleccionado.Id;
                        nombreJefePasaMetodo = jefeSeleccionado.Nombre;
                    }

                    var nuevoEmpBD = new Empleado
                    {
                        IdEmpleado = nuevoId,
                        IdCargo = idCargoSQL,
                        IdJefe = idJefeSQL,
                        NombreCompleto = txtNombre.Text,
                        DocumentoLegal = txtDui.Text,
                        EstadoActivo = true,
                        Contrasena = txtPassword.Text,
                        CorreoElectronico = correoIngresado,
                        SalarioActual = cargoSeleccionado.SalarioBase
                    };

                    db.Empleado.Add(nuevoEmpBD);
                    db.SaveChanges();

                    NodoEmpleado nuevoNodoArbol = new NodoEmpleado(
                        nuevoId,
                        txtDui.Text,
                        txtNombre.Text,
                        nombreCargo,
                        (double)cargoSeleccionado.SalarioBase,
                        correoIngresado,
                        txtPassword.Text
                    );

                    if (idJefeSQL == null)
                        miEmpresa.Raiz = nuevoNodoArbol;
                    else
                        miEmpresa.Insertar(nuevoNodoArbol, idJefeSQL);

                    AN_Jerarquia.EnviarConfirmacion(nuevoNodoArbol, nombreJefePasaMetodo);
                }

                RefrescarUIArbol(true);
                MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombre.Clear(); txtDui.Clear(); txtUsername.Clear(); txtPassword.Clear(); cmbJefe.SelectedIndex = -1; cmbCargo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el empleado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validación: Obligar a seleccionar un empleado
            if (cmbActualizarSeleccion.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, busque y seleccione un empleado para actualizar sus datos.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtActualizarNombre.Text) || cmbActualizarCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa Nombre y Cargo.");
                return;
            }

            if (cmbEscalaSalarial.SelectedIndex > 0 && string.IsNullOrWhiteSpace(txtMotivoAumento.Text))
            {
                MessageBox.Show("Si asigna una Escala Salarial superior a la base, DEBE escribir una justificación del aumento.", "Justificación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoAumento.Focus();
                return;
            }

            NodoEmpleado empAEditar = (NodoEmpleado)cmbActualizarSeleccion.SelectedItem;
            string idNuevoJefe = null;

            if (cmbActualizarJefe.Enabled && cmbActualizarJefe.SelectedIndex != -1)
            {
                NodoEmpleado nuevoJefe = (NodoEmpleado)cmbActualizarJefe.SelectedItem;
                idNuevoJefe = nuevoJefe.Id;
            }

            try
            {
                double salarioFinal = 0;
                using (var db = new SistemaRRHHEntities2())
                {
                    // 1. Obtenemos el ID exacto del cargo seleccionado
                    int idCargoNuevo = (int)cmbActualizarCargo.SelectedValue;
                    var cargoBD = db.Cargo.FirstOrDefault(c => c.IdCargo == idCargoNuevo);

                    if (cargoBD != null)
                    {
                        switch (cmbEscalaSalarial.SelectedIndex)
                        {
                            case 0: salarioFinal = (double)cargoBD.SalarioBase; break;
                            case 1: salarioFinal = (double)(cargoBD.SalarioBase + cargoBD.BonoEscala1); break;
                            case 2: salarioFinal = (double)(cargoBD.SalarioBase + cargoBD.BonoEscala2); break;
                            case 3: salarioFinal = (double)(cargoBD.SalarioBase + cargoBD.BonoEscala3); break;
                        }
                    }

                    // 2. Buscamos el registro real en la base de datos
                    var empBD = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == empAEditar.Id);
                    if (empBD != null)
                    {
                        // CORRECCIÓN CRUCIAL: Comparamos usando IDs de la BD (empBD.IdCargo == idCargoNuevo) 
                        // en lugar de comparar las cadenas de texto de los puestos.
                        if (salarioFinal == (double)empBD.SalarioActual &&
                            empBD.NombreCompleto == txtActualizarNombre.Text &&
                            empBD.IdCargo == idCargoNuevo &&
                            ((empBD.IdJefe == idNuevoJefe) || (string.IsNullOrEmpty(empBD.IdJefe) && string.IsNullOrEmpty(idNuevoJefe))))
                        {
                            MessageBox.Show("El empleado ya posee esta escala salarial y no se detectaron cambios en sus otros datos.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 3. Si pasa la validación, actualizamos primero el árbol en memoria RAM
                        bool exito = miEmpresa.ActualizarEmpleado(empAEditar.Id, txtActualizarNombre.Text, cargoBD.NombreRol, salarioFinal, idNuevoJefe);
                        if (exito)
                        {
                            // 4. Aplicamos los cambios al objeto de Entity Framework
                            empBD.NombreCompleto = txtActualizarNombre.Text;
                            empBD.IdCargo = idCargoNuevo; // Aquí se guarda el nuevo depto de forma implícita
                            empBD.IdJefe = idNuevoJefe;
                            empBD.SalarioActual = (decimal)salarioFinal;

                            if (cmbEscalaSalarial.SelectedIndex > 0)
                            {
                                var nuevoHistorial = new HistorialSalarial
                                {
                                    IdEmpleado = empAEditar.Id,
                                    Monto = (decimal)salarioFinal,
                                    TipoModificacion = "Aumento por Escala " + cmbEscalaSalarial.SelectedIndex,
                                    MotivoJustificacion = txtMotivoAumento.Text,
                                    FechaAplicacion = DateTime.Now
                                };
                                db.HistorialSalarial.Add(nuevoHistorial);
                            }

                            // 5. Impactamos la base de datos de SQL Server
                            db.SaveChanges();

                            MessageBox.Show("Datos y Escala Salarial actualizados correctamente en el sistema.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMotivoAumento.Clear();

                            // 6. Forzamos el redibujado y actualización del DataGrid
                            RefrescarUIArbol(true);
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar la jerarquía. Verifica que el nuevo jefe sea válido y no genere ciclos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la base de datos al actualizar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbActualizarSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActualizarSeleccion.SelectedIndex != -1)
            {
                txtActualizarNombre.Enabled = true;
                cmbActualizarCargo.Enabled = true;
                cmbEscalaSalarial.Enabled = true;
                txtMotivoAumento.Enabled = true;
                btnActualizar.Enabled = true;

                NodoEmpleado empSeleccionado = (NodoEmpleado)cmbActualizarSeleccion.SelectedItem;

                txtActualizarNombre.Text = empSeleccionado.Nombre;
                textBox1.Text = empSeleccionado.Dui;

                // Limpiamos los items antes de ir a la BD
                cmbEscalaSalarial.Items.Clear();

                using (var db = new SistemaRRHHEntities2())
                {
                    var empleadoReal = db.Empleado.Include("Cargo").FirstOrDefault(emp => emp.IdEmpleado == empSeleccionado.Id);

                    if (empleadoReal != null && empleadoReal.Cargo != null)
                    {
                        var cargoBD = empleadoReal.Cargo;

                        // 1. LLENAMOS EL COMBOBOX DINÁMICAMENTE CON LOS MONTOS
                        cmbEscalaSalarial.Items.Add($"Salario Base (${cargoBD.SalarioBase})");
                        cmbEscalaSalarial.Items.Add($"Escala 1 (${cargoBD.SalarioBase + cargoBD.BonoEscala1})");
                        cmbEscalaSalarial.Items.Add($"Escala 2 (${cargoBD.SalarioBase + cargoBD.BonoEscala2})");
                        cmbEscalaSalarial.Items.Add($"Escala 3 (${cargoBD.SalarioBase + cargoBD.BonoEscala3})");

                        // 2. Escudo contra nulos
                        if (cmbActualizarDepartamento.DataSource != null)
                        {
                            if (cargoBD.IdDepartamento.HasValue)
                                cmbActualizarDepartamento.SelectedValue = cargoBD.IdDepartamento.Value;
                            else
                                cmbActualizarDepartamento.SelectedIndex = -1;
                        }

                        if (cmbActualizarCargo.DataSource != null)
                        {
                            cmbActualizarCargo.SelectedValue = cargoBD.IdCargo;
                        }

                        // 3. DETECTOR DE SUELDO
                        if (empSeleccionado.Sueldo == (double)(cargoBD.SalarioBase + cargoBD.BonoEscala3))
                            cmbEscalaSalarial.SelectedIndex = 3;
                        else if (empSeleccionado.Sueldo == (double)(cargoBD.SalarioBase + cargoBD.BonoEscala2))
                            cmbEscalaSalarial.SelectedIndex = 2;
                        else if (empSeleccionado.Sueldo == (double)(cargoBD.SalarioBase + cargoBD.BonoEscala1))
                            cmbEscalaSalarial.SelectedIndex = 1;
                        else
                            cmbEscalaSalarial.SelectedIndex = 0;
                    }
                }

                cmbActualizarDepartamento.Enabled = true;
                cmbActualizarCargo.Enabled = true;

                if (empSeleccionado.Jefe != null)
                {
                    cmbActualizarJefe.Enabled = true;
                    foreach (NodoEmpleado item in cmbActualizarJefe.Items)
                    {
                        if (item.Id == empSeleccionado.Jefe.Id)
                        {
                            cmbActualizarJefe.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    cmbActualizarJefe.SelectedIndex = -1;
                    cmbActualizarJefe.Enabled = false;
                }
            }
            else
            {
                txtActualizarNombre.Clear();
                cmbEscalaSalarial.Items.Clear();
                txtMotivoAumento.Clear();
                textBox1.Clear();

                cmbActualizarJefe.SelectedIndex = -1;
                cmbActualizarDepartamento.SelectedIndex = -1;
                cmbActualizarCargo.DataSource = null;

                txtActualizarNombre.Enabled = false;
                cmbActualizarDepartamento.Enabled = false;
                cmbActualizarCargo.Enabled = false;
                cmbEscalaSalarial.Enabled = false;
                txtMotivoAumento.Enabled = false;
                cmbActualizarJefe.Enabled = false;
                btnActualizar.Enabled = false;
            }
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            if (miEmpresa.Raiz == null) return;

            // Usar el tamaño ya calculado (se actualiza al modificar el árbol)
            Size espacioNecesario = tamañoArbolCache;

            Graphics lienzo = e.Graphics;
            lienzo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            lienzo.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Ajustar el AutoScrollMinSize considerando el zoom
            panelArbol.AutoScrollMinSize = new Size(
                (int)(Math.Max(espacioNecesario.Width + 40, panelArbol.ClientSize.Width) * factorZoom),
                (int)(Math.Max(espacioNecesario.Height + 40, panelArbol.ClientSize.Height) * factorZoom)
            );

            // Aplicar transformaciones de scroll y zoom
            lienzo.TranslateTransform(panelArbol.AutoScrollPosition.X, panelArbol.AutoScrollPosition.Y);
            lienzo.ScaleTransform(factorZoom, factorZoom);

            // Calcular ancho de dibujo y posición inicial
            int anchoDibujo = Math.Max(espacioNecesario.Width, panelArbol.ClientSize.Width - 20);
            int xInicial = anchoDibujo / 2;
            int yInicial = 20;

            // Dibujar el árbol
            DibujarNodoAdaptable(miEmpresa.Raiz, xInicial, yInicial, lienzo, anchoDibujo, espacioNecesario.Height + 40, 0);

            // Resetear transformaciones
            lienzo.ResetTransform();
        }

        // Calcula el espacio total que ocupará el árbol (ancho y alto)
        private Size CalcularEspacioArbol(NodoEmpleado nodo, int nivel)
        {
            int anchoTarjeta = Math.Min(120, 200); // Ancho fijo por tarjeta
            int altoTarjeta = 50;
            int margenVertical = 80;

            if (nodo.Subalternos.Count == 0)
            {
                // Hoja: solo ocupa su tarjeta
                return new Size(anchoTarjeta + 40, altoTarjeta + 20);
            }

            int anchoTotalHijos = 0;
            int altoMaximoHijo = 0;

            foreach (var hijo in nodo.Subalternos)
            {
                Size espacioHijo = CalcularEspacioArbol(hijo, nivel + 1);
                anchoTotalHijos += espacioHijo.Width;
                altoMaximoHijo = Math.Max(altoMaximoHijo, espacioHijo.Height);
            }

            int anchoNecesario = Math.Max(anchoTarjeta + 40, anchoTotalHijos);
            int altoNecesario = altoTarjeta + margenVertical + altoMaximoHijo;

            return new Size(anchoNecesario, altoNecesario);
        }

        private void DibujarNodoAdaptable(NodoEmpleado nodo, int x, int y, Graphics lienzo,
                                           int espacioDisponible, int altoPanel, int nivel)
        {
            // Tamaño de la tarjeta ajustable
            int anchoTarjeta = Math.Min(130, Math.Max(100, espacioDisponible / 4));
            int altoTarjeta = 50;

            // Margen vertical entre niveles
            int margenVertical = 80;

            // Ajustamos para que no se salga del área de dibujo
            int rectX = Math.Max(10, x - (anchoTarjeta / 2));
            int rectY = y;

            Rectangle rectNode = new Rectangle(rectX, rectY, anchoTarjeta, altoTarjeta);

            // Dibujamos la tarjeta con color que varía según el nivel
            Color colorFondo;
            switch (nivel)
            {
                case 0: colorFondo = Color.LightSteelBlue; break;
                case 1: colorFondo = Color.LightBlue; break;
                case 2: colorFondo = Color.LightCyan; break;
                default: colorFondo = Color.LightGray; break;
            }

            using (Brush fondo = new SolidBrush(colorFondo))
            using (Pen borde = new Pen(Color.Black, 1))
            {
                lienzo.FillRectangle(fondo, rectNode);
                lienzo.DrawRectangle(borde, rectNode);
            }

            // Texto dentro de la tarjeta - FUENTE MÁS PEQUEÑA para que quepa
            string textoMostrar = $"{nodo.Nombre}\n{nodo.Puesto}";

            // Calculamos el tamaño de fuente según el nivel y espacio
            float tamanoFuente = Math.Max(6.5f, 10f - nivel * 1.2f);

            using (Font fuente = new Font("Segoe UI", tamanoFuente, FontStyle.Regular))
            using (StringFormat formatoCentrado = new StringFormat())
            {
                formatoCentrado.Alignment = StringAlignment.Center;
                formatoCentrado.LineAlignment = StringAlignment.Center;

                // Medir si el texto cabe en la tarjeta
                SizeF tamanoTexto = lienzo.MeasureString(textoMostrar, fuente, anchoTarjeta);

                // Si no cabe, reducimos aún más la fuente
                if (tamanoTexto.Height > altoTarjeta || tamanoTexto.Width > anchoTarjeta)
                {
                    float factorEscala = Math.Min(altoTarjeta / tamanoTexto.Height, anchoTarjeta / tamanoTexto.Width);
                    using (Font fuenteReducida = new Font("Segoe UI", tamanoFuente * factorEscala * 0.9f, FontStyle.Regular))
                    {
                        lienzo.DrawString(textoMostrar, fuenteReducida, Brushes.Black, rectNode, formatoCentrado);
                    }
                }
                else
                {
                    lienzo.DrawString(textoMostrar, fuente, Brushes.Black, rectNode, formatoCentrado);
                }
            }

            // Dibujar hijos (SIN RESTRICCIÓN DE ESPACIO - el scroll se encarga)
            int cantidadHijos = nodo.Subalternos.Count;
            if (cantidadHijos > 0)
            {
                // Calculamos el espacio para cada hijo
                int espacioPorHijo = Math.Max(espacioDisponible / cantidadHijos, anchoTarjeta + 20);
                int xInicialHijos = x - ((espacioPorHijo * cantidadHijos) / 2) + (espacioPorHijo / 2);
                int yHijos = y + altoTarjeta + margenVertical;

                for (int i = 0; i < cantidadHijos; i++)
                {
                    NodoEmpleado hijo = nodo.Subalternos[i];
                    int xHijo = xInicialHijos + (i * espacioPorHijo);

                    // Línea conectora
                    int parentBottomX = x;
                    int parentBottomY = y + altoTarjeta;
                    int childTopX = xHijo;
                    int childTopY = yHijos;

                    using (Pen linea = new Pen(Color.Gray, 1))
                    {
                        lienzo.DrawLine(linea, parentBottomX, parentBottomY, childTopX, childTopY);
                    }

                    // Dibujar hijo recursivamente
                    DibujarNodoAdaptable(hijo, xHijo, yHijos, lienzo,
                                        espacioPorHijo, altoPanel, nivel + 1);
                }
            }
        }

        private void panelStats_Paint(object sender, PaintEventArgs e)
        {
            Graphics lienzo = e.Graphics;
            lienzo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            List<string> nombresDepartamentos = new List<string>();
            List<int> cantidades = new List<int>();
            int totalEmpleadosEnDepartamentos = 0;

            // CONSULTA DIRECTA A LA BASE DE DATOS (Fácil, Seguro y Exacto)
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var estadisticas = db.Empleado
                        .Where(emp => emp.EstadoActivo == true && emp.Cargo != null && emp.Cargo.Departamento != null)
                        .GroupBy(emp => emp.Cargo.Departamento.NombreDepartamento)
                        .Select(g => new { Departamento = g.Key, Cantidad = g.Count() })
                        .ToList();

                    foreach (var stat in estadisticas)
                    {
                        nombresDepartamentos.Add(stat.Departamento);
                        cantidades.Add(stat.Cantidad);
                        totalEmpleadosEnDepartamentos += stat.Cantidad;
                    }
                }
            }
            catch
            {
                return;
            }

            // Prevención del error de División por cero (el que causaba la gráfica negra)
            if (totalEmpleadosEnDepartamentos == 0)
            {
                lienzo.DrawString("Aún no hay empleados asignados a departamentos para mostrar estadísticas.", this.Font, Brushes.Gray, 10, 10);
                return;
            }

            Color[] coloresPastel = { Color.Tomato, Color.CornflowerBlue, Color.MediumSeaGreen, Color.Gold, Color.MediumOrchid, Color.Orange, Color.Turquoise };
            Rectangle rectPastel = new Rectangle(10, 30, 100, 100);
            float anguloInicio = 0f;
            int leyendaY = 30;

            for (int i = 0; i < cantidades.Count; i++)
            {
                float porcentaje = (float)cantidades[i] / totalEmpleadosEnDepartamentos;
                float anguloBarrido = porcentaje * 360f;

                using (Brush brochaColor = new SolidBrush(coloresPastel[i % coloresPastel.Length]))
                {
                    lienzo.FillPie(brochaColor, rectPastel, anguloInicio, anguloBarrido);

                    int leyendaX = 130;
                    lienzo.FillRectangle(brochaColor, leyendaX, leyendaY, 15, 15);
                }

                lienzo.DrawPie(Pens.Black, rectPastel, anguloInicio, anguloBarrido);
                int rectX = 130;
                lienzo.DrawRectangle(Pens.Black, rectX, leyendaY, 15, 15);

                string textoLeyenda = $"{nombresDepartamentos[i]}: {cantidades[i]} emp. ({porcentaje:P1})";
                lienzo.DrawString(textoLeyenda, this.Font, Brushes.Black, rectX + 20, leyendaY);

                anguloInicio += anguloBarrido;
                leyendaY += 25;
            }

            lienzo.DrawString($"Total en departamentos: {totalEmpleadosEnDepartamentos}", new Font(this.Font, FontStyle.Bold), Brushes.Black, 130, leyendaY + 10);
        }

        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar != (char)Keys.Back)
            {
                string textoSinGuion = txtDui.Text.Replace("-", "");
                if (textoSinGuion.Length == 8 && !txtDui.Text.Contains("-"))
                {
                    txtDui.Text += "-";
                    txtDui.SelectionStart = txtDui.Text.Length;
                }
            }
        }

        private void PanelArbol_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                float zoomAnterior = factorZoom;

                if (e.Delta > 0)
                    factorZoom = Math.Min(factorZoom + ZOOM_STEP, ZOOM_MAX);
                else if (e.Delta < 0)
                    factorZoom = Math.Max(factorZoom - ZOOM_STEP, ZOOM_MIN);

                // Ajustar el scroll para mantener el punto bajo el cursor
                if (zoomAnterior != factorZoom)
                {
                    Point mousePos = panelArbol.PointToClient(Cursor.Position);

                    float relacionZoom = factorZoom / zoomAnterior;

                    // Ajustar la posición del scroll para el efecto de zoom centrado
                    panelArbol.AutoScrollPosition = new Point(
                        (int)((mousePos.X + Math.Abs(panelArbol.AutoScrollPosition.X)) * relacionZoom - mousePos.X),
                        (int)((mousePos.Y + Math.Abs(panelArbol.AutoScrollPosition.Y)) * relacionZoom - mousePos.Y)
                    );

                    panelArbol.Invalidate();
                    ActualizarLabelZoom();
                }
            }
        }
      
        private void cmbEliminar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbEliminar.SelectedIndex != -1)
            {
                btnEliminar.Enabled = true; 

                NodoEmpleado empSeleccionado = (NodoEmpleado)cmbEliminar.SelectedItem;
                if (empSeleccionado.Subalternos.Count > 0)
                    cmbNuevoJefe.Enabled = true;
                else
                {
                    cmbNuevoJefe.Enabled = false;
                    cmbNuevoJefe.SelectedIndex = -1;
                }
            }
            else
            {
                btnEliminar.Enabled = false; 
                cmbNuevoJefe.Enabled = false;
                cmbNuevoJefe.SelectedIndex = -1;
            }
        }

        private void ActualizarLabelZoom()
        {
            if (lblZoom != null)
            {
                lblZoom.Text = $"🔍 {factorZoom * 100:F0}%";
            }
        }

        private void RecalcularTamañoArbol()
        {
            if (miEmpresa.Raiz == null)
                tamañoArbolCache = Size.Empty;
            else
                tamañoArbolCache = CalcularEspacioArbol(miEmpresa.Raiz, 0);
        }

        private void cmbActualizarDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mismo escudo aquí
            if (cmbActualizarDepartamento.SelectedIndex != -1 && cmbActualizarDepartamento.SelectedValue is int)
            {
                int idDepto = (int)cmbActualizarDepartamento.SelectedValue;
                try
                {
                    using (var db = new SistemaRRHHEntities2())
                    {
                        var cargos = db.Cargo.Where(c => c.IdDepartamento == idDepto).ToList();
                        cmbActualizarCargo.DisplayMember = "NombreRol";
                        cmbActualizarCargo.ValueMember = "IdCargo";
                        cmbActualizarCargo.DataSource = cargos;
                        // No le ponemos SelectedIndex = -1 aquí para no borrar la selección al cargar el empleado
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                cmbActualizarCargo.DataSource = null;
            }
        }
    }
}