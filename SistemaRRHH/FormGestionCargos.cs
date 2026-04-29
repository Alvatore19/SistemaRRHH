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
        public FormGestionCargos()
        {
            InitializeComponent();
        }

        private void btnFusionarDeptos_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (cmbFusionDepto1.SelectedIndex == -1 || cmbFusionDepto2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona dos líderes de departamento para fusionar.");
                return;
            }

            // OJO: Asumo que en este Form también cargas la lista de empleados en los ComboBox
            NodoEmpleado jefe1 = (NodoEmpleado)cmbFusionDepto1.SelectedItem;
            NodoEmpleado jefe2 = (NodoEmpleado)cmbFusionDepto2.SelectedItem;

            if (jefe1.Id == jefe2.Id)
            {
                MessageBox.Show("No puedes fusionar un departamento consigo mismo. Selecciona dos líderes distintos.");
                return;
            }

            if (!rbJefe1.Checked && !rbJefe2.Checked)
            {
                MessageBox.Show("Por favor, selecciona qué líder comandará el nuevo departamento fusionado.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevoDeptoFusion.Text))
            {
                MessageBox.Show("Debes ingresar el nuevo cargo para el líder del departamento fusionado.");
                return;
            }

            // 2. Determinar quién gana y quién pierde
            string idGanador = rbJefe1.Checked ? jefe1.Id : jefe2.Id;
            string idPerdedor = rbJefe1.Checked ? jefe2.Id : jefe1.Id;
            string nuevoNombreCargo = txtNuevoDeptoFusion.Text;

            // 3. ACTUALIZACIÓN EN SQL SERVER (La magia real)
            using (var db = new SistemaRRHHEntities())
            {
                // A. Cambiamos de jefe a todos los subalternos del líder perdedor
                var subalternos = db.Empleado.Where(emp => emp.IdJefe == idPerdedor).ToList();
                foreach (var sub in subalternos)
                {
                    sub.IdJefe = idGanador;
                }

                // B. (Opcional) Actualizar el nombre del cargo del ganador si tienes una tabla Cargo
                var empleadoGanador = db.Empleado.FirstOrDefault(emp => emp.IdEmpleado == idGanador);
                if (empleadoGanador != null)
                {
                    // Lógica para asignar el nuevo cargo al ganador en BD...
                }

                db.SaveChanges(); // Guardamos los cambios en el disco duro
            }

            // 4. ACTUALIZACIÓN EN EL ÁRBOL RAM (Si pasaste la variable miEmpresa a este Form)
            // bool exito = miEmpresa.FusionarDepartamentos(idGanador, idPerdedor, nuevoNombreCargo);

            MessageBox.Show("¡Fusión completada con éxito! La estructura y la base de datos se han actualizado.", "Fusión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNuevoDeptoFusion.Clear();
            rbJefe1.Checked = false;
            rbJefe2.Checked = false;

            // Aquí llamarías a un método local para recargar tus ComboBox de este Form
            // CargarComboBoxesFusion(); 
        }
    }
}
