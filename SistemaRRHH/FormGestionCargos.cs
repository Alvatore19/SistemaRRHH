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
    public partial class FormGestionCargos : Form
    {
        // Variables para controlar qué registro está seleccionado en las tablas
        private int idCargoSeleccionado = 0;
        private int idDeptoSeleccionado = 0;

        public FormGestionCargos()
        {
            InitializeComponent();

            // Eventos de Cargos
            btnGuardarCargo.Click += btnGuardarCargo_Click;
            btnEditarCargo.Click += btnEditarCargo_Click;
            btnEliminarCargo.Click += btnEliminarCargo_Click;
            dgvCargos.CellClick += DgvCargos_CellClick;

            // Eventos de Departamentos
            btnGuardarDepto.Click += btnGuardarDepto_Click;
            btnEditarDepto.Click += btnEditarDepto_Click;
            btnEliminarDepto.Click += btnEliminarDepto_Click;
            dgvDepartamentos.CellClick += DgvDepartamentos_CellClick;

            // Carga inicial del formulario
            this.Load += FormGestionCargos_Load;
        }

        private void FormGestionCargos_Load(object sender, EventArgs e)
        {
            CargarDepartamentosDataGrid();
            CargarComboBoxDepartamentos();
            CargarCargosDataGrid();
        }

        // ==========================================
        // LÓGICA DE CARGOS (CRUD)
        // ==========================================

        private void CargarCargosDataGrid()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var listaCargos = db.Cargo.Select(c => new
                    {
                        ID = c.IdCargo,
                        Cargo = c.NombreRol,
                        Nivel = c.NivelJerarquico,
                        Departamento = c.Departamento != null ? c.Departamento.NombreDepartamento : "General / Sin Asignar",
                        Sueldo_Base = c.SalarioBase,
                        Bono_Año_1 = c.BonoEscala1,
                        Bono_Año_3 = c.BonoEscala2,
                        Bono_Año_5 = c.BonoEscala3,
                        IdDeptoOculto = c.IdDepartamento
                    }).ToList();

                    dgvCargos.DataSource = listaCargos;
                    dgvCargos.Columns["IdDeptoOculto"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar la tabla de cargos: " + ex.Message); }
        }

        private void DgvCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCargos.Rows[e.RowIndex];

                idCargoSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txtNombreCargo.Text = fila.Cells["Cargo"].Value.ToString();
                numNivelJerarquico.Value = Convert.ToDecimal(fila.Cells["Nivel"].Value);
                txtSueldoBase.Text = fila.Cells["Sueldo_Base"].Value.ToString();
                txtEscala1.Text = fila.Cells["Bono_Año_1"].Value.ToString();
                txtEscala2.Text = fila.Cells["Bono_Año_3"].Value.ToString();
                txtEscala3.Text = fila.Cells["Bono_Año_5"].Value.ToString();

                if (fila.Cells["IdDeptoOculto"].Value != null)
                {
                    cmbDepartamento.SelectedValue = fila.Cells["IdDeptoOculto"].Value;
                }
                else
                {
                    cmbDepartamento.SelectedIndex = -1;
                }
            }
        }

        private void btnGuardarCargo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCargo.Text) || string.IsNullOrWhiteSpace(txtSueldoBase.Text))
            {
                MessageBox.Show("El nombre del cargo y el sueldo base son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? idDeptoSeleccionadoParaCargo = null;
                if (cmbDepartamento.SelectedIndex != -1)
                {
                    idDeptoSeleccionadoParaCargo = (int)cmbDepartamento.SelectedValue;
                }

                using (var db = new SistemaRRHHEntities2())
                {
                    var nuevoCargo = new Cargo
                    {
                        NombreRol = txtNombreCargo.Text.Trim(),
                        NivelJerarquico = (int)numNivelJerarquico.Value,
                        SalarioBase = Convert.ToDecimal(txtSueldoBase.Text),
                        IdDepartamento = idDeptoSeleccionadoParaCargo,

                        BonoEscala1 = string.IsNullOrWhiteSpace(txtEscala1.Text) ? 0 : Convert.ToDecimal(txtEscala1.Text),
                        BonoEscala2 = string.IsNullOrWhiteSpace(txtEscala2.Text) ? 0 : Convert.ToDecimal(txtEscala2.Text),
                        BonoEscala3 = string.IsNullOrWhiteSpace(txtEscala3.Text) ? 0 : Convert.ToDecimal(txtEscala3.Text)
                    };

                    db.Cargo.Add(nuevoCargo);
                    db.SaveChanges();

                    MessageBox.Show("Cargo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposCargo();
                    CargarCargosDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cargo. Verifica que los valores numéricos sean correctos.\nDetalle: " + ex.Message,
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarCargo_Click(object sender, EventArgs e)
        {
            if (idCargoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un cargo de la tabla para editarlo.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var cargoBD = db.Cargo.Find(idCargoSeleccionado);
                    if (cargoBD != null)
                    {
                        cargoBD.NombreRol = txtNombreCargo.Text.Trim();
                        cargoBD.NivelJerarquico = (int)numNivelJerarquico.Value;
                        cargoBD.SalarioBase = Convert.ToDecimal(txtSueldoBase.Text);
                        cargoBD.BonoEscala1 = string.IsNullOrWhiteSpace(txtEscala1.Text) ? 0 : Convert.ToDecimal(txtEscala1.Text);
                        cargoBD.BonoEscala2 = string.IsNullOrWhiteSpace(txtEscala2.Text) ? 0 : Convert.ToDecimal(txtEscala2.Text);
                        cargoBD.BonoEscala3 = string.IsNullOrWhiteSpace(txtEscala3.Text) ? 0 : Convert.ToDecimal(txtEscala3.Text);

                        if (cmbDepartamento.SelectedIndex != -1)
                            cargoBD.IdDepartamento = (int)cmbDepartamento.SelectedValue;
                        else
                            cargoBD.IdDepartamento = null;

                        db.SaveChanges();
                        MessageBox.Show("Cargo actualizado exitosamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCamposCargo();
                        CargarCargosDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cargo: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCargo_Click(object sender, EventArgs e)
        {
            if (idCargoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un cargo de la tabla para eliminarlo.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar este cargo? Esta acción puede afectar a los empleados asignados a él.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (var db = new SistemaRRHHEntities2())
                    {
                        var cargoBD = db.Cargo.Find(idCargoSeleccionado);
                        if (cargoBD != null)
                        {
                            db.Cargo.Remove(cargoBD);
                            db.SaveChanges();
                            MessageBox.Show("Cargo eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCamposCargo();
                            CargarCargosDataGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar el cargo porque actualmente hay empleados usándolo. Reasigna a los empleados primero.\n" + ex.Message,
                        "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCamposCargo()
        {
            txtNombreCargo.Clear();
            txtSueldoBase.Clear();
            txtEscala1.Clear();
            txtEscala2.Clear();
            txtEscala3.Clear();
            numNivelJerarquico.Value = 4;
            cmbDepartamento.SelectedIndex = -1;
            idCargoSeleccionado = 0;
        }

        // ==========================================
        // LÓGICA DE DEPARTAMENTOS (CRUD COMPLETO)
        // ==========================================

        private void CargarComboBoxDepartamentos()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var deptos = db.Departamento.ToList();
                    cmbDepartamento.DataSource = deptos;
                    cmbDepartamento.DisplayMember = "NombreDepartamento";
                    cmbDepartamento.ValueMember = "IdDepartamento";
                    cmbDepartamento.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar ComboBox de Deptos: " + ex.Message);
            }
        }

        private void CargarDepartamentosDataGrid()
        {
            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    var listaDeptos = db.Departamento.Select(d => new
                    {
                        ID = d.IdDepartamento,
                        Departamento = d.NombreDepartamento
                    }).ToList();

                    dgvDepartamentos.DataSource = listaDeptos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
        }

        private void DgvDepartamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDepartamentos.Rows[e.RowIndex];

                idDeptoSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txtNombreDepto.Text = fila.Cells["Departamento"].Value.ToString();
            }
        }

        private void btnGuardarDepto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDepto.Text))
            {
                MessageBox.Show("Por favor, escribe el nombre del departamento.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    bool existe = db.Departamento.Any(d => d.NombreDepartamento == txtNombreDepto.Text.Trim());
                    if (existe)
                    {
                        MessageBox.Show("Este departamento ya existe en la base de datos.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var nuevoDepto = new Departamento
                    {
                        NombreDepartamento = txtNombreDepto.Text.Trim()
                    };

                    db.Departamento.Add(nuevoDepto);
                    db.SaveChanges();

                    MessageBox.Show("Departamento creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposDepto();

                    // Refrescamos tablas y combobox
                    CargarDepartamentosDataGrid();
                    CargarComboBoxDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarDepto_Click(object sender, EventArgs e)
        {
            if (idDeptoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un departamento de la tabla para editarlo.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreDepto.Text))
            {
                MessageBox.Show("El nombre del departamento no puede quedar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new SistemaRRHHEntities2())
                {
                    string nuevoNombre = txtNombreDepto.Text.Trim();

                    // Validar que el nuevo nombre no le pertenezca ya a OTRO departamento
                    bool nombreOcupado = db.Departamento.Any(d => d.NombreDepartamento == nuevoNombre && d.IdDepartamento != idDeptoSeleccionado);
                    if (nombreOcupado)
                    {
                        MessageBox.Show("Ya existe otro departamento con ese nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var deptoBD = db.Departamento.Find(idDeptoSeleccionado);
                    if (deptoBD != null)
                    {
                        deptoBD.NombreDepartamento = nuevoNombre;
                        db.SaveChanges();

                        MessageBox.Show("Departamento actualizado exitosamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCamposDepto();
                        CargarDepartamentosDataGrid();
                        CargarComboBoxDepartamentos(); // Refrescar combobox por si el nombre cambió
                        CargarCargosDataGrid();        // Refrescar cargos por si alguno pertenece al depto editado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el departamento: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDepto_Click(object sender, EventArgs e)
        {
            if (idDeptoSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un departamento de la tabla para eliminarlo.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar este departamento? Los cargos vinculados quedarán como 'Sin Asignar'.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (var db = new SistemaRRHHEntities2())
                    {
                        var deptoBD = db.Departamento.Find(idDeptoSeleccionado);
                        if (deptoBD != null)
                        {
                            db.Departamento.Remove(deptoBD);
                            db.SaveChanges();

                            MessageBox.Show("Departamento eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCamposDepto();
                            CargarDepartamentosDataGrid();
                            CargarComboBoxDepartamentos();
                            CargarCargosDataGrid(); // Refrescamos los cargos para que reflejen el "Sin asignar"
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el departamento.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCamposDepto()
        {
            txtNombreDepto.Clear();
            idDeptoSeleccionado = 0;
        }
    }
}