using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class Gestion_Empleados : Form
    {
        AN_Jerarquia miEmpresa = new AN_Jerarquia();
        int contadorEmpleados = 1;

        List<NodoEmpleado> listaTodosLosEmpleados = new List<NodoEmpleado>();

        public Gestion_Empleados()
        {
            InitializeComponent();

            panelArbol.Paint += panelArbol_Paint;
            panelStats.Paint += panelStats_Paint;
            btnEliminar.Enabled = false;
            cmbNuevoJefe.Enabled = false;

            // Controles de Actualizar apagados por defecto
            txtActualizarNombre.Enabled = false;
            txtActualizarCargo.Enabled = false;
            txtActualizarSueldo.Enabled = false;
            cmbActualizarJefe.Enabled = false;
            btnActualizar.Enabled = false;

            // --- CARGAR CARGOS PREDETERMINADOS ---
            cmbCargo.Items.Add("Director General");
            cmbCargo.Items.Add("Gerente de Departamento");
            cmbCargo.Items.Add("Supervisor");
            cmbCargo.Items.Add("Empleado");
            cmbCargo.Items.Add("Analista de Recursos Humanos");

            txtDui.MaxLength = 10;
            txtDui.KeyPress += txtDui_KeyPress;

            // --- ENCENDER BUSCADOR INTELIGENTE <---
            cmbActualizarSeleccion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbActualizarSeleccion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEliminar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEliminar.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ActualizarComboBoxes()
        {
            // 1. Rompemos los enlaces de TODOS los ComboBoxes
            cmbJefe.DataSource = null;
            cmbEliminar.DataSource = null;
            cmbNuevoJefe.DataSource = null;
            cmbActualizarSeleccion.DataSource = null;
            cmbActualizarJefe.DataSource = null;
            cmbFusion1.DataSource = null; 
            cmbFusion2.DataSource = null;

            // 2. Enlazamos la lista general a los ComboBoxes que usan a TODOS los empleados
            cmbJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbEliminar.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbNuevoJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbActualizarSeleccion.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);
            cmbActualizarJefe.DataSource = new List<NodoEmpleado>(listaTodosLosEmpleados);

            // 3. Llenamos los ComboBoxes de Fusión SOLO con Jefes de Departamento (hijos directos del Dueño/Raíz)
            if (miEmpresa.Raiz != null)
            {
                List<NodoEmpleado> jefesDepartamento = listaTodosLosEmpleados
                    .Where(emp => emp.Jefe == miEmpresa.Raiz)
                    .ToList();

                cmbFusion1.DataSource = new List<NodoEmpleado>(jefesDepartamento);
                cmbFusion2.DataSource = new List<NodoEmpleado>(jefesDepartamento);
            }

            // 4. Reseteamos las selecciones para que arranquen en blanco
            cmbJefe.SelectedIndex = -1;
            cmbEliminar.SelectedIndex = -1;
            cmbNuevoJefe.SelectedIndex = -1;
            cmbActualizarSeleccion.SelectedIndex = -1;
            cmbActualizarJefe.SelectedIndex = -1;
            if (cmbFusion1.Items.Count > 0) cmbFusion1.SelectedIndex = -1;
            if (cmbFusion2.Items.Count > 0) cmbFusion2.SelectedIndex = -1;
        }


        private void btnIngresarEmpleado_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDACIONES DE CAMPOS OBLIGATORIOS ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbCargo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSueldo.Text) ||
                string.IsNullOrWhiteSpace(txtDui.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos (Nombre, Cargo, Sueldo, DUI, Correo y Contraseña).",
                    "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. VALIDACIONES DE FORMATO (Sueldo y DUI) ---
            double sueldo = 0;
            if (!double.TryParse(txtSueldo.Text, out sueldo))
            {
                MessageBox.Show("El sueldo debe ser un valor numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDui.Text, @"^\d{8}-\d$"))
            {
                MessageBox.Show("El formato del DUI es incorrecto (Ejemplo: 12345678-9).", "DUI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDui.Focus(); 
                return;        
            }

            // --- 3. VALIDACIÓN DE UNICIDAD (DUI y Correo/Username) ---

            // Validar DUI único
            if (listaTodosLosEmpleados.Any(emp => emp.Dui == txtDui.Text))
            {
                MessageBox.Show("Este número de DUI ya se encuentra registrado.", "DUI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDui.Focus(); 
                txtDui.SelectAll(); 
                return; 
            }

            // Validar Formato de Correo
            if (!txtUsername.Text.Contains("@") || !txtUsername.Text.Contains("."))
            {
                MessageBox.Show("El nombre de usuario debe ser un correo electrónico válido.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // Validar Correo único (Username)
            bool correoYaExiste = listaTodosLosEmpleados.Any(emp =>
                emp.Username.Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (correoYaExiste)
            {
                MessageBox.Show("Este correo electrónico ya está asignado a otro empleado.", "Correo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // --- 4. VALIDACIÓN DE JEFE OBLIGATORIO ---
            if (listaTodosLosEmpleados.Count > 0 && cmbJefe.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un jefe para el nuevo empleado.", "Jefe Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 5. CREACIÓN E INSERCIÓN ---
            string nuevoId = "EMP-" + contadorEmpleados.ToString();
            NodoEmpleado nuevoEmpleado = new NodoEmpleado(
                nuevoId,
                txtDui.Text,
                txtNombre.Text,
                cmbCargo.SelectedItem.ToString(),
                sueldo,
                txtUsername.Text.Trim(),
                txtPassword.Text
            );

            string nombreJefePasaMetodo = "N/A (Director General)";

            // --- 4. INSERCIÓN EN EL ÁRBOL ---
            if (cmbJefe.SelectedIndex == -1)
            {
                miEmpresa.Raiz = nuevoEmpleado;
            }
            else
            {
                NodoEmpleado jefeSeleccionado = (NodoEmpleado)cmbJefe.SelectedItem;
                nombreJefePasaMetodo = jefeSeleccionado.Nombre;
                miEmpresa.Insertar(nuevoEmpleado, jefeSeleccionado.Id);
            }

            // --- 6. NOTIFICACIÓN POR CORREO ---
            AN_Jerarquia.EnviarConfirmacion(nuevoEmpleado, nombreJefePasaMetodo);

            // --- 7. ACTUALIZACIÓN DE INTERFAZ ---
            contadorEmpleados++;
            listaTodosLosEmpleados.Add(nuevoEmpleado);
            ActualizarComboBoxes();

            MessageBox.Show($"Empleado registrado y correo enviado a {nuevoEmpleado.Username}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Clear();
            txtSueldo.Clear();
            txtDui.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtNombre.Focus();

            panelArbol.Invalidate();
            panelStats.Invalidate();
        }

        private string ObtenerIdDelComboBox(ComboBox cmb)
        {
            NodoEmpleado seleccionado = (NodoEmpleado)cmb.SelectedItem;
            return seleccionado.Id;
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            if (miEmpresa.Raiz != null)
            {
                Graphics lienzo = e.Graphics;
                int xInicial = panelArbol.Width / 2;
                int yInicial = 40; 
                DibujarNodo(miEmpresa.Raiz, xInicial, yInicial, lienzo, panelArbol.Width);
            }
        }

        private void DibujarNodo(NodoEmpleado nodo, int x, int y, Graphics lienzo, int espacioDisponible)
        {
            // --- Configuración de Estilo de la "Tarjeta" del Empleado ---
            int anchoTarjeta = 110; 
            int altoTarjeta = 45;  

            int rectX = x - (anchoTarjeta / 2);
            int rectY = y - (altoTarjeta / 2);
            Rectangle rectNode = new Rectangle(rectX, rectY, anchoTarjeta, altoTarjeta);

            // --- 1. Dibujar el FONDO y el BORDE del rectángulo ---
            lienzo.FillRectangle(Brushes.LightBlue, rectNode);
            lienzo.DrawRectangle(Pens.Black, rectNode);

            // --- 2. Preparar y Dibujar el TEXTO ---
            Font fuente = this.Font;
            string textoMostrar = $"{nodo.Nombre}\n{nodo.Puesto}\n";

            StringFormat formatoCentrado = new StringFormat();
            formatoCentrado.Alignment = StringAlignment.Center;     
            formatoCentrado.LineAlignment = StringAlignment.Center;
            lienzo.DrawString(textoMostrar, fuente, Brushes.Black, rectNode, formatoCentrado);

            // --- 3. Calcular y Dibujar subalternos ---
            int cantidadHijos = nodo.Subalternos.Count;
            if (cantidadHijos > 0)
            {
                int anchoPorHijo = espacioDisponible / cantidadHijos;
                int xHijo = x - (espacioDisponible / 2) + (anchoPorHijo / 2);

                int yHijo = y + 100;

                foreach (NodoEmpleado subalterno in nodo.Subalternos)
                {
                    int parentBottomX = x;
                    int parentBottomY = y + (altoTarjeta / 2);

                    int childTopX = xHijo;
                    int childTopY = yHijo - (altoTarjeta / 2);

                    lienzo.DrawLine(Pens.Black, parentBottomX, parentBottomY, childTopX, childTopY);

                    DibujarNodo(subalterno, xHijo, yHijo, lienzo, anchoPorHijo);

                    xHijo += anchoPorHijo;
                }
            }
        }

        private void cmbEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEliminar.SelectedIndex != -1)
            {
                NodoEmpleado nodoSeleccionado = (NodoEmpleado)cmbEliminar.SelectedItem;
                btnEliminar.Enabled = true;

                if (nodoSeleccionado.Subalternos.Count > 0)
                {
                    cmbNuevoJefe.Enabled = true;
                }
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
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.SelectedIndex == -1) return;

            NodoEmpleado nodoAEliminar = (NodoEmpleado)cmbEliminar.SelectedItem;

            if (nodoAEliminar == miEmpresa.Raiz && nodoAEliminar.Subalternos.Count > 0)
            {
                MessageBox.Show("No puedes despedir al Director General si aún hay empleados.");
                return;
            }

            string idNuevoJefe = "";

            if (nodoAEliminar.Subalternos.Count > 0)
            {
                if (cmbNuevoJefe.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione a quién se le asignarán los subalternos.");
                    return;
                }

                NodoEmpleado nuevoJefe = (NodoEmpleado)cmbNuevoJefe.SelectedItem;

                if (nuevoJefe.Id == nodoAEliminar.Id)
                {
                    MessageBox.Show("El nuevo jefe no puede ser la misma persona a despedir.");
                    return;
                }

                idNuevoJefe = nuevoJefe.Id;
            }

            bool exito = miEmpresa.EliminarConReasignacion(nodoAEliminar.Id, idNuevoJefe);

            if (exito)
            {
                MessageBox.Show("Empleado despedido y árbol actualizado.");

                listaTodosLosEmpleados.RemoveAll(emp => emp.Id == nodoAEliminar.Id);

                ActualizarComboBoxes();

                panelArbol.Invalidate(); panelStats.Invalidate();
            }
        }

        private void cmbActualizarSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActualizarSeleccion.SelectedIndex != -1)
            {
                txtActualizarNombre.Enabled = true;
                txtActualizarCargo.Enabled = true;
                txtActualizarSueldo.Enabled = true;
                btnActualizar.Enabled = true;

                NodoEmpleado empSeleccionado = (NodoEmpleado)cmbActualizarSeleccion.SelectedItem;

                txtActualizarNombre.Text = empSeleccionado.Nombre;
                txtActualizarCargo.Text = empSeleccionado.Puesto;
                txtActualizarSueldo.Text = empSeleccionado.Sueldo.ToString();

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
                // 2. Si se limpia la selección, borramos textos y APAGAMOS TODO
                txtActualizarNombre.Clear();
                txtActualizarCargo.Clear();
                txtActualizarSueldo.Clear();
                cmbActualizarJefe.SelectedIndex = -1;

                txtActualizarNombre.Enabled = false;
                txtActualizarCargo.Enabled = false;
                txtActualizarSueldo.Enabled = false;
                cmbActualizarJefe.Enabled = false;
                btnActualizar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya alguien seleccionado
            if (cmbActualizarSeleccion.SelectedIndex == -1) return;

            // 2. Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtActualizarNombre.Text) ||
                string.IsNullOrWhiteSpace(txtActualizarCargo.Text) ||
                string.IsNullOrWhiteSpace(txtActualizarSueldo.Text))
            {
                MessageBox.Show("Por favor, completa Nombre, Cargo y Sueldo.");
                return;
            }

            double nuevoSueldo = 0;
            if (!double.TryParse(txtActualizarSueldo.Text, out nuevoSueldo))
            {
                MessageBox.Show("El sueldo debe ser un número válido.");
                return;
            }

            // 3. Extraer el ID del empleado a editar y el ID del nuevo jefe (si aplica)
            NodoEmpleado empAEditar = (NodoEmpleado)cmbActualizarSeleccion.SelectedItem;
            string idNuevoJefe = "";

            if (cmbActualizarJefe.Enabled && cmbActualizarJefe.SelectedIndex != -1)
            {
                NodoEmpleado nuevoJefe = (NodoEmpleado)cmbActualizarJefe.SelectedItem;
                idNuevoJefe = nuevoJefe.Id;
            }

            // 4. ¡Delegamos la responsabilidad a la clase del Árbol!
            bool exito = miEmpresa.ActualizarEmpleado(empAEditar.Id, txtActualizarNombre.Text, txtActualizarCargo.Text, nuevoSueldo, idNuevoJefe);

            if (exito)
            {
                MessageBox.Show("Datos actualizados correctamente.");

                ActualizarComboBoxes();

                panelArbol.Invalidate(); panelStats.Invalidate();
            }
            else
            {
                MessageBox.Show("Error al actualizar. Verifica que el nuevo jefe sea válido (no puede ser él mismo ni alguien de su propio departamento).",
                    "Error de Jerarquía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFusionar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (cmbFusion1.SelectedIndex == -1 || cmbFusion2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona dos jefes de departamento para fusionar.");
                return;
            }

            NodoEmpleado jefe1 = (NodoEmpleado)cmbFusion1.SelectedItem;
            NodoEmpleado jefe2 = (NodoEmpleado)cmbFusion2.SelectedItem;

            if (jefe1.Id == jefe2.Id)
            {
                MessageBox.Show("No puedes fusionar un departamento consigo mismo. Selecciona dos jefes distintos.");
                return;
            }

            if (!rbJefe1.Checked && !rbJefe2.Checked)
            {
                MessageBox.Show("Por favor, selecciona qué jefe liderará el nuevo departamento (usando los botones redondos).");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevoCargoFusion.Text))
            {
                MessageBox.Show("Debes ingresar el nuevo cargo para el jefe del departamento fusionado.");
                return;
            }

            // 2. Determinar quién gana y quién pierde
            string idGanador = rbJefe1.Checked ? jefe1.Id : jefe2.Id;
            string idPerdedor = rbJefe1.Checked ? jefe2.Id : jefe1.Id;
            string nuevoCargo = txtNuevoCargoFusion.Text;

            // 3. Ejecutar la magia del árbol
            bool exito = miEmpresa.FusionarDepartamentos(idGanador, idPerdedor, nuevoCargo);

            if (exito)
            {
                MessageBox.Show("¡Fusión completada con éxito! La estructura se ha actualizado.", "Fusión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNuevoCargoFusion.Clear();
                rbJefe1.Checked = false;
                rbJefe2.Checked = false;

                ActualizarComboBoxes();

                panelArbol.Invalidate(); panelStats.Invalidate();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar fusionar los departamentos.");
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

            // 1. Recopilar datos de los departamentos
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

            // 2. Configurar colores bonitos para el pastel
            Color[] coloresPastel = { Color.Tomato, Color.CornflowerBlue, Color.MediumSeaGreen, Color.Gold, Color.MediumOrchid, Color.Orange, Color.Turquoise };

            // 3. Dibujar el gráfico de pastel
            Rectangle rectPastel = new Rectangle(10, 30, 150, 150);
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

                // 4. Dibujar la leyenda (a la derecha del pastel)
                int leyendaX = 180;

                lienzo.FillRectangle(brochaColor, leyendaX, leyendaY, 15, 15);
                lienzo.DrawRectangle(Pens.Black, leyendaX, leyendaY, 15, 15);

                string textoLeyenda = $"{nombresDepartamentos[i]}: {cantidades[i]} emp. ({porcentaje:P1})";
                lienzo.DrawString(textoLeyenda, this.Font, Brushes.Black, leyendaX + 20, leyendaY);

                anguloInicio += anguloBarrido;
                leyendaY += 25;
            }

            lienzo.DrawString($"Total en departamentos: {totalEmpleadosEnDepartamentos}", new Font(this.Font, FontStyle.Bold), Brushes.Black, 180, leyendaY + 10);
        }

        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. BLOQUEAR LETRAS Y SÍMBOLOS
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                return;
            }

            // 2. AUTO-GENERAR EL GUION
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

        private void label6_Click(object sender, EventArgs e){}
        private void label10_Click(object sender, EventArgs e){}
    }
}
