using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FrmAsistencia : Form
    {
        private string _nivelUsuario;
        private string _idEmpleadoActual;

        // Variables exclusivas del Empleado
        private bool trabajando = false;
        private DateTime entrada;
        private Timer timerAsistencia;

        public FrmAsistencia(string nivel, string idEmpleado)
        {
            InitializeComponent();
            _nivelUsuario = nivel;
            _idEmpleadoActual = idEmpleado;

            // Configuramos el timer, pero no lo iniciamos aún
            ConfigurarTimer();
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            // 1. Limpieza inicial
            pnlDirector.Visible = false;
            pnlEmpleado.Visible = false;

            // 2. Posicionamiento de paneles (Mismo lugar, mismo tamaño)
            pnlDirector.Location = pnlEmpleado.Location = new Point(20, 80);
            pnlDirector.Size = pnlEmpleado.Size = new Size(1030, 500);

            // 3. Selección de vista según el rol
            switch (_nivelUsuario)
            {
                case "1": // Director General
                case "2": // Gerentes
                    lblTituloPrincipal.Text = "Control de Asistencia Global";
                    pnlDirector.Visible = true;
                    pnlDirector.BringToFront();
                    ConfigurarVistaDirector();
                    break;

                default: // Analistas, Desarrolladores, Empleados (Niveles 3, 4, 5)
                    lblTituloPrincipal.Text = "Mi Registro de Asistencia";
                    pnlEmpleado.Visible = true;
                    pnlEmpleado.BringToFront();
                    ConfigurarVistaEmpleado();
                    break;
            }
        }

        // ==========================================
        // LÓGICA: DIRECTOR / GERENTE
        // ==========================================
        private void ConfigurarVistaDirector()
        {
            dgvAsistenciaGlobal.AutoGenerateColumns = true;

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new string[] { "Todos", "A Tiempo", "Media Jornada", "Incompleto", "En Proceso" });
            cboEstado.SelectedIndex = 0;
            chkUsarFecha.Checked = false;

            CargarTodoDirector();
        }

        private void CargarTodoDirector()
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
                    }).ToList();

                dgvAsistenciaGlobal.DataSource = data;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var db = new SistemaRRHHEntities())
            {
                var query = db.Asistencia.AsQueryable();

                if (cboEstado.Text != "Todos")
                    query = query.Where(x => x.EstadoJornada == cboEstado.Text);

                if (chkUsarFecha.Checked)
                {
                    DateTime fecha = dtpFecha.Value.Date;
                    query = query.Where(x => DbFunctions.TruncateTime(x.Fecha) == fecha);
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
                }).ToList();

                dgvAsistenciaGlobal.DataSource = result;

                if (result.Count == 0)
                    MessageBox.Show("No se encontraron registros.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAsistenciaGlobal_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAsistenciaGlobal.Rows)
            {
                if (row.Cells["EstadoJornada"].Value == null) continue;
                string estado = row.Cells["EstadoJornada"].Value.ToString();

                if (estado == "A Tiempo") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (estado == "Media Jornada") row.DefaultCellStyle.BackColor = Color.Khaki;
                else if (estado == "Incompleto") row.DefaultCellStyle.BackColor = Color.LightCoral;
                else row.DefaultCellStyle.BackColor = Color.LightSkyBlue; // En Proceso
            }
        }

        // ==========================================
        // LÓGICA: EMPLEADO NORMAL
        // ==========================================
        private void ConfigurarVistaEmpleado()
        {
            CargarDatosPersonales();
            CargarHistorialEmpleado();
            VerificarAsistenciaEnCurso();
        }

        private void ConfigurarTimer()
        {
            timerAsistencia = new Timer();
            timerAsistencia.Interval = 1000;
            timerAsistencia.Tick += TimerAsistencia_Tick;
        }

        private void TimerAsistencia_Tick(object sender, EventArgs e)
        {
            if (trabajando)
            {
                TimeSpan t = DateTime.Now - entrada;
                lblContador.Text = t.ToString(@"hh\:mm\:ss");
            }
        }

        private void CargarDatosPersonales()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var emp = db.Empleado.Include("Cargo").FirstOrDefault(e => e.IdEmpleado == _idEmpleadoActual);
                if (emp != null)
                {
                    lblNombre.Text = "Nombre: " + emp.NombreCompleto;
                    lblDUI.Text = "DUI: " + emp.DocumentoLegal;
                    lblCargo.Text = "Cargo: " + (emp.Cargo != null ? emp.Cargo.NombreRol : "Sin cargo");
                    lblEstadoActual.Text = emp.EstadoActivo ? "Estado: ACTIVO" : "Estado: INACTIVO";
                }
            }
        }

        private void CargarHistorialEmpleado()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var lista = db.Asistencia
                    .Where(a => a.IdEmpleado == _idEmpleadoActual)
                    .OrderByDescending(a => a.Fecha)
                    .Select(a => new
                    {
                        a.Fecha,
                        a.HoraEntrada,
                        a.HoraSalida,
                        a.HorasTrabajadas,
                        a.EstadoJornada
                    }).ToList();

                dgvHistorialPersonal.DataSource = lista;
            }
        }

        private void VerificarAsistenciaEnCurso()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var hoy = DateTime.Now.Date;
                var asistenciaHoy = db.Asistencia.FirstOrDefault(a => a.IdEmpleado == _idEmpleadoActual && a.Fecha == hoy);

                if (asistenciaHoy != null && asistenciaHoy.EstadoJornada == "En Proceso")
                {
                    // Ya había marcado entrada, reactivamos el timer
                    entrada = asistenciaHoy.HoraEntrada.Value;
                    trabajando = true;
                    btnAccionAsistencia.Text = "🛑 FINALIZAR JORNADA";
                    btnAccionAsistencia.BackColor = Color.Red;
                    lblEstadoActual.Text = "Estado: EN PROCESO";
                    timerAsistencia.Start();
                }
                else if (asistenciaHoy != null)
                {
                    // Ya terminó su jornada
                    btnAccionAsistencia.Enabled = false;
                    btnAccionAsistencia.Text = "JORNADA COMPLETADA";
                    btnAccionAsistencia.BackColor = Color.Gray;
                    lblEstadoActual.Text = "Estado: FINALIZADO";
                }
            }
        }

        private void btnAccionAsistencia_Click(object sender, EventArgs e)
        {
            if (!trabajando) IniciarAsistencia();
            else FinalizarAsistencia();
        }

        private void IniciarAsistencia()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var asistencia = new Asistencia
                {
                    LlaveHash = _idEmpleadoActual + "_" + DateTime.Now.ToString("yyyyMMdd"),
                    IdEmpleado = _idEmpleadoActual,
                    Fecha = DateTime.Now.Date,
                    HoraEntrada = DateTime.Now,
                    EstadoJornada = "En Proceso"
                };

                db.Asistencia.Add(asistencia);
                db.SaveChanges();
            }

            entrada = DateTime.Now;
            trabajando = true;
            lblEstadoActual.Text = "Estado: EN PROCESO";
            btnAccionAsistencia.Text = "🛑 FINALIZAR JORNADA";
            btnAccionAsistencia.BackColor = Color.Red;
            timerAsistencia.Start();
            CargarHistorialEmpleado();
        }

        private void FinalizarAsistencia()
        {
            DialogResult r = MessageBox.Show("¿Está seguro que desea finalizar su jornada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.No) return;

            timerAsistencia.Stop();

            using (var db = new SistemaRRHHEntities())
            {
                var hoy = DateTime.Now.Date;
                var asistencia = db.Asistencia.FirstOrDefault(a => a.IdEmpleado == _idEmpleadoActual && a.Fecha == hoy);

                if (asistencia != null)
                {
                    DateTime salida = DateTime.Now;
                    TimeSpan t = salida - entrada;
                    decimal horas = (decimal)t.TotalHours;

                    string estado = (horas >= 8) ? "A Tiempo" : (horas >= 4) ? "Media Jornada" : "Incompleto";
                    decimal horasExtra = horas > 8 ? horas - 8 : 0;
                    decimal pagoExtra = horasExtra * 20;

                    asistencia.HoraSalida = salida;
                    asistencia.HorasTrabajadas = horas;
                    asistencia.EstadoJornada = estado;
                    db.SaveChanges();

                    lblHorasExtra.Text = $"Horas Extra: {horasExtra:0.00} | Pago: ${pagoExtra:0.00}";
                }
            }

            trabajando = false;
            lblEstadoActual.Text = "Estado: FINALIZADO";
            btnAccionAsistencia.Text = "JORNADA COMPLETADA";
            btnAccionAsistencia.BackColor = Color.Gray;
            btnAccionAsistencia.Enabled = false; // Bloqueamos el botón para que no marque 2 veces
            CargarHistorialEmpleado();
        }
    }
}

