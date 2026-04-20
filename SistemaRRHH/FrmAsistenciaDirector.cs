using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FrmAsistenciaDirector : Form
    {
        public FrmAsistenciaDirector()
        {
            InitializeComponent();
            this.Load += FrmAsistenciaDirector_Load;
        }

        private void FrmAsistenciaDirector_Load(object sender, EventArgs e)
        {
            dgvAsistencia.AutoGenerateColumns = true;

            cboEstado.Items.Clear();
            cboEstado.Items.Add("Todos");
            cboEstado.Items.Add("A Tiempo");
            cboEstado.Items.Add("Media Jornada");
            cboEstado.Items.Add("Incompleto");
            cboEstado.SelectedIndex = 0;

            chkUsarFecha.Checked = false;

            CargarTodo();
        }

      
        private void CargarTodo()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var data = db.Asistencia
                    .Select(a => new
                    {
                        a.IdEmpleado,
                        a.Fecha,
                        a.HoraEntrada,
                        a.HoraSalida,
                        a.HorasTrabajadas,
                        a.EstadoJornada,

                        HorasExtra = (a.HorasTrabajadas > 8 ? a.HorasTrabajadas - 8 : 0),
                        PagoExtra = (a.HorasTrabajadas > 8 ? (a.HorasTrabajadas - 8) * 20 : 0)
                    })
                    .ToList();

                dgvAsistencia.DataSource = null;
                dgvAsistencia.DataSource = data;

                if (data.Count == 0)
                    MessageBox.Show("No hay registros de asistencia.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var db = new SistemaRRHHEntities())
            {
                var query = db.Asistencia.AsQueryable();

                // FILTRO ESTADO
                if (cboEstado.Text != "Todos")
                    query = query.Where(x => x.EstadoJornada == cboEstado.Text);

                // FILTRO FECHA
                if (chkUsarFecha.Checked)
                {
                    DateTime fecha = dtpFecha.Value.Date;

                    query = query.Where(x =>
                        DbFunctions.TruncateTime(x.Fecha) == fecha);
                }

                var result = query.Select(a => new
                {
                    a.IdEmpleado,
                    a.Fecha,
                    a.HoraEntrada,
                    a.HoraSalida,
                    a.HorasTrabajadas,
                    a.EstadoJornada,

                    HorasExtra = (a.HorasTrabajadas > 8 ? a.HorasTrabajadas - 8 : 0),
                    PagoExtra = (a.HorasTrabajadas > 8 ? (a.HorasTrabajadas - 8) * 20 : 0)
                })
                .ToList();

                dgvAsistencia.DataSource = null;
                dgvAsistencia.DataSource = result;

                if (result.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros con esos filtros.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        // COLORES
        private void dgvAsistencia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAsistencia.Rows)
            {
                if (row.Cells["EstadoJornada"].Value == null) continue;

                string estado = row.Cells["EstadoJornada"].Value.ToString();

                if (estado == "A Tiempo")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (estado == "Media Jornada")
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                else
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}

