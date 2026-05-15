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

        List<NodoEmpleado> listaTodosLosEmpleados = new List<NodoEmpleado>();

        string rolUsuarioActual;
        string idUsuarioActual;
        int contadorEmpleados = 1;
        // Variables para el zoom
        private float factorZoom = 1.0f;
        private const float ZOOM_MIN = 0.3f;
        private const float ZOOM_MAX = 2.5f;
        private const float ZOOM_STEP = 0.1f;
        private PointF puntoCentroZoom = PointF.Empty;

        public FormGestionEmpleados(string nivelUsuario, string idEmpleadoLogueado)
        {
            InitializeComponent();

            // Asignamos la sesión real que viene del Login/Dashboard
            idUsuarioActual = idEmpleadoLogueado;

            // Basado en tu SQL: Nivel 1 = Director, Nivel 2 = Analista
            rolUsuarioActual = (nivelUsuario == "1") ? "Director General" : "Analista de RRHH";

            panelArbol.Paint += panelArbol_Paint;
            panelStats.Paint += panelStats_Paint;
            btnEliminar.Enabled = false;
            cmbNuevoJefe.Enabled = false;

            panelArbol.Resize += panelArbol_Resize;
            panelArbol.AutoScroll = true;
            panelArbol.MouseWheel += PanelArbol_MouseWheel;
            ActualizarLabelZoom();

            // Controles de Actualizar apagados por defecto
            txtActualizarNombre.Enabled = false;
            txtActualizarCargo.Enabled = false;
            cmbActualizarJefe.Enabled = false;
            btnActualizar.Enabled = false;

            // Cargar cargos en el ComboBox
            try
            {
                using (var db = new SistemaRRHHEntities())
                {
                    var listaCargos = db.Cargo.ToList();
                    cmbCargo.DataSource = listaCargos;
                    cmbCargo.DisplayMember = "NombreRol";
                    cmbCargo.ValueMember = "IdCargo";
                    cmbCargo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            txtDui.MaxLength = 10;
            txtDui.KeyPress += txtDui_KeyPress;

            // Configurar buscador inteligente
            cmbActualizarSeleccion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbActualizarSeleccion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEliminar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEliminar.AutoCompleteSource = AutoCompleteSource.ListItems;

            // 🛡️ Ocultar la pestaña de aprobaciones si NO es el Director General
            if (rolUsuarioActual != "Director General")
            {
                tabControlVistas.TabPages.Remove(tabAprobaciones);
                btnEliminar.Text = "Solicitar Despido (Requiere Aprobación)";
                btnEliminar.BackColor = Color.DarkOrange;
            }

            // Cargar tablas de datos (Excel style)
            CargarDirectorioDataGrid();
            if (rolUsuarioActual == "Director General") CargarAprobacionesDataGrid();
            if (rolUsuarioActual != "Director General")
            {
                tabControlVistas.TabPages.Remove(tabAprobaciones);
                btnEliminar.Text = "Solicitar Despido (Requiere Aprobación)";
                btnEliminar.BackColor = Color.DarkOrange;
            }

            // ¡EL ESLABÓN PERDIDO! (Responde a tus preguntas 3 y 4)
            CargarEmpleadosDesdeBD();

            panelArbol.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(panelArbol, true);
            panelStats.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(panelStats, true);
        }

        private void panelArbol_Resize(object sender, EventArgs e)
        {
            panelArbol.Invalidate(); // Fuerza el repintado con las nuevas dimensiones
        }

        // --- MÉTODOS PARA LLENAR LOS DATAGRIDVIEW ---
        private void CargarDirectorioDataGrid()
        {
            try
            {
                using (var db = new SistemaRRHHEntities())
                {
                    var directorio = (from e in db.Empleado
                                      join c in db.Cargo on e.IdCargo equals c.IdCargo
                                      join j in db.Empleado on e.IdJefe equals j.IdEmpleado into jefes
                                      from jefe in jefes.DefaultIfEmpty() // Left Join
                                      where e.EstadoActivo == true
                                      select new
                                      {
                                          Código = e.IdEmpleado,
                                          Nombre = e.NombreCompleto,
                                          DUI = e.DocumentoLegal,
                                          Cargo = c.NombreRol,
                                          Jefe_Inmediato = jefe != null ? jefe.NombreCompleto : "N/A (Cúspide)",
                                          Sueldo = c.SalarioBase
                                      }).ToList();

                    dgvEmpleados.DataSource = directorio;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error al cargar directorio: " + ex.Message); }
        }

        private void CargarEmpleadosDesdeBD()
        {
            try
            {
                using (var db = new SistemaRRHHEntities())
                {
                    var empleadosBD = db.Empleado.Include("Cargo")
                                                 .Where(e => e.EstadoActivo == true)
                                                 .OrderBy(e => e.Cargo.NivelJerarquico)
                                                 .ToList();

                    foreach (var emp in empleadosBD)
                    {
                        // Reconstruimos el nodo en la RAM
                        NodoEmpleado nuevoNodo = new NodoEmpleado(
                            emp.IdEmpleado,
                            emp.DocumentoLegal,
                            emp.NombreCompleto,
                            emp.Cargo.NombreRol,
                            (double)emp.Cargo.SalarioBase,
                            emp.CorreoElectronico,
                            emp.Contrasena
                        );

                        // Si no tiene jefe, es la Raíz (El Director General)
                        if (string.IsNullOrEmpty(emp.IdJefe))
                        {
                            miEmpresa.Raiz = nuevoNodo;
                        }
                        else
                        {
                            // Si tiene jefe, lo insertamos buscando al jefe en el árbol
                            miEmpresa.Insertar(nuevoNodo, emp.IdJefe);
                        }

                        listaTodosLosEmpleados.Add(nuevoNodo);
                    }

                    // Actualizamos el contador para que el próximo ID no choque con los existentes
                    // Si hay 5 empleados, el contador iniciará en 6 para crear "EMP-6"
                    contadorEmpleados = listaTodosLosEmpleados.Count + 1;
                }

                // Refrescamos las tablas, los combobox y mandamos a pintar los gráficos
                ActualizarComboBoxes();
                panelArbol.Invalidate();
                panelStats.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la estructura organizacional: " + ex.Message);
            }
        }

        private void CargarAprobacionesDataGrid()
        {
            try
            {
                using (var db = new SistemaRRHHEntities())
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

        private void ActualizarComboBoxes()
        {
            cmbJefe.DataSource = null; cmbEliminar.DataSource = null; cmbNuevoJefe.DataSource = null;
            cmbActualizarSeleccion.DataSource = null; cmbActualizarJefe.DataSource = null;

            cmbJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbEliminar.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbNuevoJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbActualizarSeleccion.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbActualizarJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);

            cmbJefe.SelectedIndex = -1; cmbEliminar.SelectedIndex = -1; cmbNuevoJefe.SelectedIndex = -1;
            cmbActualizarSeleccion.SelectedIndex = -1; cmbActualizarJefe.SelectedIndex = -1;

            CargarDirectorioDataGrid();
            if (rolUsuarioActual == "Director General") CargarAprobacionesDataGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.SelectedIndex == -1) return;

            NodoEmpleado nodoAEliminar = (NodoEmpleado)cmbEliminar.SelectedItem;
            string motivo = txtMotivoDespido.Text.Trim();

            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe ingresar un motivo para justificar el despido.", "Motivo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nodoAEliminar == miEmpresa.Raiz && nodoAEliminar.Subalternos.Count > 0)
            {
                MessageBox.Show("No puedes despedir al Director General activo."); return;
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

            // RAMIFICACIÓN SEGÚN EL ROL
            using (var db = new SistemaRRHHEntities())
            {
                if (rolUsuarioActual == "Director General")
                {
                    // DESPIDO DIRECTO (Modo Dios)
                    var empBD = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == nodoAEliminar.Id);
                    if (empBD != null)
                    {
                        var subalternosBD = db.Empleado.Where(emp => emp.IdJefe == nodoAEliminar.Id).ToList();
                        foreach (var sub in subalternosBD) sub.IdJefe = idNuevoJefe;

                        db.Empleado.Remove(empBD);
                        db.SaveChanges();
                    }

                    miEmpresa.EliminarConReasignacion(nodoAEliminar.Id, idNuevoJefe);
                    listaTodosLosEmpleados.RemoveAll(emp => emp.Id == nodoAEliminar.Id);

                    MessageBox.Show("Despido procesado inmediatamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // SOLICITUD DE DESPIDO (Modo Analista)
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
                ActualizarComboBoxes();
                panelArbol.Invalidate(); panelStats.Invalidate();
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

            using (var db = new SistemaRRHHEntities())
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
            listaTodosLosEmpleados.RemoveAll(emp => emp.Id == idADespedir);

            MessageBox.Show("Despido Aprobado y Ejecutado.");
            ActualizarComboBoxes();
            panelArbol.Invalidate(); panelStats.Invalidate();
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

            using (var db = new SistemaRRHHEntities())
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
            // --- 1. VALIDACIONES DE CAMPOS OBLIGATORIOS ---
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

            if (listaTodosLosEmpleados.Count > 0 && cmbJefe.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un jefe para el nuevo empleado.", "Jefe Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoId = "EMP-" + contadorEmpleados.ToString();
            string correoIngresado = txtUsername.Text.Trim();
            Cargo cargoSeleccionado = (Cargo)cmbCargo.SelectedItem;
            string nombreCargo = cargoSeleccionado.NombreRol;
            int idCargoSQL = cargoSeleccionado.IdCargo;

            // --- 2. VALIDACIÓN DE UNICIDAD Y GUARDADO EN SQL SERVER ---
            using (var db = new SistemaRRHHEntities())
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

                // --- VALIDACIÓN DE LÍMITES DE CARGOS ---
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
                    CorreoElectronico = correoIngresado
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

                listaTodosLosEmpleados.Add(nuevoNodoArbol);
                AN_Jerarquia.EnviarConfirmacion(nuevoNodoArbol, nombreJefePasaMetodo);
            }

            contadorEmpleados++;
            ActualizarComboBoxes();
            MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Clear(); txtDui.Clear(); txtUsername.Clear(); txtPassword.Clear();
            panelArbol.Invalidate(); panelStats.Invalidate();
        }

        private void cmbActualizarSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActualizarSeleccion.SelectedIndex != -1)
            {
                txtActualizarNombre.Enabled = true;
                txtActualizarCargo.Enabled = true;
                cmbEscalaSalarial.Enabled = true;
                txtMotivoAumento.Enabled = true;
                btnActualizar.Enabled = true;

                NodoEmpleado empSeleccionado = (NodoEmpleado)cmbActualizarSeleccion.SelectedItem;

                txtActualizarNombre.Text = empSeleccionado.Nombre;
                txtActualizarCargo.Text = empSeleccionado.Puesto;
                textBox1.Text = empSeleccionado.Dui;

                cmbEscalaSalarial.Items.Clear();
                using (var db = new SistemaRRHHEntities())
                {
                    var cargoBD = db.Cargo.FirstOrDefault(c => c.NombreRol == empSeleccionado.Puesto);
                    if (cargoBD != null)
                    {
                        cmbEscalaSalarial.Items.Add($"Base: ${cargoBD.SalarioBase}");
                        cmbEscalaSalarial.Items.Add($"Escala 1: ${cargoBD.SalarioBase + cargoBD.BonoEscala1}");
                        cmbEscalaSalarial.Items.Add($"Escala 2: ${cargoBD.SalarioBase + cargoBD.BonoEscala2}");
                        cmbEscalaSalarial.Items.Add($"Escala 3: ${cargoBD.SalarioBase + cargoBD.BonoEscala3}");
                        cmbEscalaSalarial.SelectedIndex = 0; 
                    }
                }

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
                txtActualizarCargo.Clear();
                cmbEscalaSalarial.Items.Clear();
                txtMotivoAumento.Clear();
                textBox1.Clear(); 
                cmbActualizarJefe.SelectedIndex = -1;

                txtActualizarNombre.Enabled = false;
                txtActualizarCargo.Enabled = false;
                cmbEscalaSalarial.Enabled = false;
                txtMotivoAumento.Enabled = false;
                cmbActualizarJefe.Enabled = false;
                btnActualizar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbActualizarSeleccion.SelectedIndex == -1) return;

            if (string.IsNullOrWhiteSpace(txtActualizarNombre.Text) || string.IsNullOrWhiteSpace(txtActualizarCargo.Text))
            {
                MessageBox.Show("Por favor, completa Nombre y Cargo.");
                return;
            }

            if (cmbEscalaSalarial.SelectedIndex > 0 && string.IsNullOrWhiteSpace(txtMotivoAumento.Text))
            {
                MessageBox.Show("Si asigna una Escala Salarial superior a la base, DEBE escribir una justificación del aumento (Ej. Ascenso, Antigüedad).", "Justificación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            bool exito = miEmpresa.ActualizarEmpleado(empAEditar.Id, txtActualizarNombre.Text, txtActualizarCargo.Text, 0, idNuevoJefe);

            if (exito)
            {
                using (var db = new SistemaRRHHEntities())
                {
                    var empBD = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == empAEditar.Id);
                    if (empBD != null)
                    {
                        empBD.NombreCompleto = txtActualizarNombre.Text;

                        var cargoBD = db.Cargo.FirstOrDefault(c => c.NombreRol == txtActualizarCargo.Text);
                        if (cargoBD != null) empBD.IdCargo = cargoBD.IdCargo;
                        if (idNuevoJefe != null) empBD.IdJefe = idNuevoJefe;

                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Datos y Escala Salarial actualizados correctamente en el sistema.");
                txtMotivoAumento.Clear();
                ActualizarComboBoxes();
                panelArbol.Invalidate(); panelStats.Invalidate();
            }
            else
            {
                MessageBox.Show("Error al actualizar. Verifica que el nuevo jefe sea válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            if (miEmpresa.Raiz == null) return;

            Graphics lienzo = e.Graphics;
            lienzo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            lienzo.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // 1. Calcular el espacio TOTAL que necesita el árbol (sin zoom)
            Size espacioNecesario = CalcularEspacioArbol(miEmpresa.Raiz, 0);

            // 2. Ajustar el AutoScrollMinSize considerando el zoom
            panelArbol.AutoScrollMinSize = new Size(
                (int)(Math.Max(espacioNecesario.Width + 40, panelArbol.ClientSize.Width) * factorZoom),
                (int)(Math.Max(espacioNecesario.Height + 40, panelArbol.ClientSize.Height) * factorZoom)
            );

            // 3. Aplicar la traslación del scroll y el zoom
            lienzo.TranslateTransform(panelArbol.AutoScrollPosition.X, panelArbol.AutoScrollPosition.Y);
            lienzo.ScaleTransform(factorZoom, factorZoom);

            // 4. Usar el ancho del árbol calculado o el del panel (el que sea mayor)
            int anchoDibujo = Math.Max(espacioNecesario.Width, panelArbol.ClientSize.Width - 20);

            // Posición inicial: centro-arriba del área de dibujo
            int xInicial = anchoDibujo / 2;
            int yInicial = 20;

            // Dibujar el árbol adaptado al espacio calculado
            DibujarNodoAdaptable(miEmpresa.Raiz, xInicial, yInicial, lienzo, anchoDibujo, espacioNecesario.Height + 40, 0);

            // Resetear transformaciones para dibujar UI
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

            if (miEmpresa.Raiz == null || miEmpresa.Raiz.Subalternos.Count == 0)
            {
                lienzo.DrawString("Aún no hay departamentos para mostrar estadísticas.", this.Font, Brushes.Gray, 10, 10);
                return;
            }

            List<string> nombresDepartamentos = new List<string>();
            List<int> cantidades = new List<int>();
            int totalEmpleadosEnDepartamentos = 0;

            foreach (NodoEmpleado jefeDep in miEmpresa.Raiz.Subalternos)
            {
                nombresDepartamentos.Add(jefeDep.Nombre + " (" + jefeDep.Puesto + ")");
                int tamanoDepartamento = miEmpresa.ContarEmpleadosSubarbol(jefeDep);
                cantidades.Add(tamanoDepartamento);
                totalEmpleadosEnDepartamentos += tamanoDepartamento;
            }

            Color[] coloresPastel = { Color.Tomato, Color.CornflowerBlue, Color.MediumSeaGreen, Color.Gold, Color.MediumOrchid, Color.Orange, Color.Turquoise };

            Rectangle rectPastel = new Rectangle(10, 30, 100, 100);
            float anguloInicio = 0f;
            int leyendaY = 30;

            lienzo.DrawString("Distribución por Departamentos", new Font(this.Font, FontStyle.Bold), Brushes.Black, 10, 5);

            for (int i = 0; i < cantidades.Count; i++)
            {
                float porcentaje = (float)cantidades[i] / totalEmpleadosEnDepartamentos;
                float anguloBarrido = porcentaje * 360f;

                Brush brochaColor = new SolidBrush(coloresPastel[i % coloresPastel.Length]);

                lienzo.FillPie(brochaColor, rectPastel, anguloInicio, anguloBarrido);
                lienzo.DrawPie(Pens.Black, rectPastel, anguloInicio, anguloBarrido);

                int leyendaX = 130;
                lienzo.FillRectangle(brochaColor, leyendaX, leyendaY, 15, 15);
                lienzo.DrawRectangle(Pens.Black, leyendaX, leyendaY, 15, 15);

                string textoLeyenda = $"{nombresDepartamentos[i]}: {cantidades[i]} emp. ({porcentaje:P1})";
                lienzo.DrawString(textoLeyenda, this.Font, Brushes.Black, leyendaX + 20, leyendaY);

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
                // Zoom con Ctrl + Rueda del mouse
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

        // Método para mostrar el nivel de zoom actual (opcional)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Oemplus) || keyData == (Keys.Control | Keys.Add))
            {
                factorZoom = Math.Min(factorZoom + ZOOM_STEP, ZOOM_MAX);
                panelArbol.Invalidate();
                ActualizarLabelZoom();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.OemMinus) || keyData == (Keys.Control | Keys.Subtract))
            {
                factorZoom = Math.Max(factorZoom - ZOOM_STEP, ZOOM_MIN);
                panelArbol.Invalidate();
                ActualizarLabelZoom();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D0))
            {
                // Ctrl + 0 = Reset zoom
                factorZoom = 1.0f;
                panelArbol.AutoScrollPosition = Point.Empty;
                panelArbol.Invalidate();
                ActualizarLabelZoom();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cmbEliminar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbEliminar.SelectedIndex != -1)
            {
                btnEliminar.Enabled = true; // <--- ¡AQUÍ ESTÁ LA SOLUCIÓN! ENCIENDE EL BOTÓN

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
                btnEliminar.Enabled = false; // <--- APAGA EL BOTÓN SI SE LIMPIA LA BÚSQUEDA
                cmbNuevoJefe.Enabled = false;
                cmbNuevoJefe.SelectedIndex = -1;
            }
        }


        private void ActualizarLabelZoom()
        {
            if (lblZoom != null)
            {
                lblZoom.Text = $"🔍 {factorZoom * 100:F0}%";
                // Opcional: tooltip con instrucciones
            }
        }

    }
}