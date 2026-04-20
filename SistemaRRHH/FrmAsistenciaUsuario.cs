using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FrmAsistenciaUsuario : Form
    {
        private string _idEmpleado;
        private bool trabajando = false;
        private DateTime entrada;
        private Timer timer;

        public FrmAsistenciaUsuario()
        {
            InitializeComponent();
        }

        public FrmAsistenciaUsuario(string idEmpleado)
        {
            InitializeComponent();
            _idEmpleado = idEmpleado;

            btnAccionAsistencia.Click += btnAccionAsistencia_Click;

            CargarDatosEmpleado();
            CargarHistorial();
            IniciarTimer();
        }

        // =========================
        // TIMER
        // =========================
        private void IniciarTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (trabajando)
            {
                TimeSpan t = DateTime.Now - entrada;
                lblContador.Text = t.ToString(@"hh\:mm\:ss");
            }
        }

        // =========================
        // DATOS EMPLEADO
        // =========================
        private void CargarDatosEmpleado()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var emp = db.Empleado
                    .Include("Cargo")
                    .FirstOrDefault(e => e.IdEmpleado == _idEmpleado);

                if (emp != null)
                {
                    lblNombre.Text = "Nombre: " + emp.NombreCompleto;
                    lblDUI.Text = "DUI: " + emp.DocumentoLegal;
                    lblCargo.Text = "Cargo: " +
                        (emp.Cargo != null ? emp.Cargo.NombreRol : "Sin cargo");

                    lblEstadoActual.Text = emp.EstadoActivo ? "Estado: ACTIVO" : "Estado: INACTIVO";
                }
            }
        }

        // =========================
        // HISTORIAL
        // =========================
        private void CargarHistorial()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var lista = db.Asistencia
                    .Where(a => a.IdEmpleado == _idEmpleado)
                    .OrderByDescending(a => a.Fecha)
                    .Select(a => new
                    {
                        a.Fecha,
                        a.HoraEntrada,
                        a.HoraSalida,
                        a.HorasTrabajadas,
                        a.EstadoJornada
                    })
                    .ToList();

                dgvHistorial.DataSource = lista;
            }
        }

        // =========================
        // BOTÓN PRINCIPAL
        // =========================
        private void btnAccionAsistencia_Click(object sender, EventArgs e)
        {
            if (!trabajando)
                IniciarAsistencia();
            else
                FinalizarAsistencia();
        }

        // =========================
        // INICIAR
        // =========================
        private void IniciarAsistencia()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var hoy = DateTime.Now.Date;

                var existe = db.Asistencia
                    .FirstOrDefault(a => a.IdEmpleado == _idEmpleado && a.Fecha == hoy);

                if (existe != null)
                {
                    MessageBox.Show("Ya tienes asistencia iniciada hoy.");
                    return;
                }

                var asistencia = new Asistencia
                {
                    LlaveHash = _idEmpleado + "_" + DateTime.Now.ToString("yyyyMMdd"),
                    IdEmpleado = _idEmpleado,
                    Fecha = hoy,
                    HoraEntrada = DateTime.Now,
                    EstadoJornada = "En Proceso"
                };

                db.Asistencia.Add(asistencia);
                db.SaveChanges();
            }

            entrada = DateTime.Now;
            trabajando = true;

            lblEstadoActual.Text = "Estado: EN PROCESO";
            btnAccionAsistencia.Text = "TERMINAR";
            btnAccionAsistencia.BackColor = System.Drawing.Color.Red;

            timer.Start();
        }

        // =========================
        // FINALIZAR CON ESTADOS
        // =========================
        private void FinalizarAsistencia()
        {
            DialogResult r = MessageBox.Show(
                "¿Está seguro que desea terminar la asistencia?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.No)
                return;

            timer.Stop();

            using (var db = new SistemaRRHHEntities())
            {
                var hoy = DateTime.Now.Date;

                var asistencia = db.Asistencia
                    .FirstOrDefault(a => a.IdEmpleado == _idEmpleado && a.Fecha == hoy);

                if (asistencia == null)
                    return;

                DateTime salida = DateTime.Now;
                TimeSpan t = salida - entrada;

                decimal horas = (decimal)t.TotalHours;

                // =========================
                // ESTADOS CORRECTOS
                // =========================
                string estado;

                if (horas >= 8)
                    estado = "A Tiempo";
                else if (horas >= 4)
                    estado = "Media Jornada";
                else
                    estado = "Incompleto";

                // =========================
                // HORAS EXTRA
                // =========================
                decimal horasExtra = horas > 8 ? horas - 8 : 0;
                decimal pagoExtra = horasExtra * 20;

                asistencia.HoraSalida = salida;
                asistencia.HorasTrabajadas = horas;
                asistencia.EstadoJornada = estado;

                db.SaveChanges();

                lblHorasExtra.Text =
                    $"Horas Extra: {horasExtra:0.00} | Pago: ${pagoExtra:0.00}";
            }

            trabajando = false;

            lblEstadoActual.Text = "Estado: FINALIZADO";
            btnAccionAsistencia.Text = "INICIAR ASISTENCIA";
            btnAccionAsistencia.BackColor = System.Drawing.Color.LightGreen;

            CargarHistorial();
        }
    }
}