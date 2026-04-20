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
    public partial class FormPortalEmpleado : Form
    {
        private string _idEmpleadoActual;

        public FormPortalEmpleado(string idEmpleado)
        {
            InitializeComponent();
            _idEmpleadoActual = idEmpleado;
        }

        private void FormPortalEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatosPersonales();
            CargarPermisos();
            CargarAsistenciasSimuladas();
            CargarBoletasSimuladas();
        }

        private void CargarDatosPersonales()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var empleado = db.Empleado
                                 .Include("Cargo")
                                 .FirstOrDefault(emp => emp.IdEmpleado == _idEmpleadoActual);

                if (empleado != null)
                {
                    txtNombre.Text = empleado.NombreCompleto;
                    txtDui.Text = empleado.DocumentoLegal;
                    txtCargo.Text = empleado.Cargo != null ? empleado.Cargo.NombreRol : "Sin Asignar";
                    txtEstado.Text = empleado.EstadoActivo ? "Activo" : "Inactivo";

                    if (!string.IsNullOrEmpty(empleado.IdJefe))
                    {
                        var jefe = db.Empleado.FirstOrDefault(j => j.IdEmpleado == empleado.IdJefe);
                        txtJefe.Text = jefe != null ? jefe.NombreCompleto : "No Encontrado";
                    }
                    else
                    {
                        txtJefe.Text = "No tiene superior";
                    }
                }
            }
        }

        private void CargarPermisos()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var misPermisos = db.SolicitudPermiso
                                    .Where(s => s.IdEmpleado == _idEmpleadoActual)
                                    .OrderByDescending(s => s.FechaSolicitud)
                                    .Select(s => new {
                                        Tipo = s.TipoPermiso,
                                        Tiempo = s.CantidadTiempo + " " + s.UnidadTiempo,
                                        Motivo = s.MotivoDetallado,
                                        Estado = s.EstadoAprobacion
                                    }).ToList();

                dgvPermisos.DataSource = misPermisos;
            }
        }

        private void CargarAsistenciasSimuladas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Hora Entrada", typeof(string));
            dt.Columns.Add("Hora Salida", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            dt.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy"), "08:00 AM", "05:00 PM", "A Tiempo");
            dt.Rows.Add(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"), "08:15 AM", "05:00 PM", "Llegada Tardía");

            dgvAsistencias.DataSource = dt;
        }

        private void CargarBoletasSimuladas()
        {
            ListaBoletas miHistorialPagos = new ListaBoletas();

            miHistorialPagos.Agregar("Marzo 2026", 1200.00, 150.00, 120.00);
            miHistorialPagos.Agregar("Febrero 2026", 1200.00, 0, 120.00);
            miHistorialPagos.Agregar("Enero 2026", 1200.00, 50.00, 120.00);

            dgvBoletas.DataSource = miHistorialPagos.ObtenerListaParaGrid();
        }
    }
}
