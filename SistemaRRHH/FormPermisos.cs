using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FormPermisos : Form
    {
        private string _nivelUsuario;
        private string _idEmpleadoActual;
        private ColaPrioridadPermisos miColaPermisos = new ColaPrioridadPermisos();

        // Modificamos el constructor para recibir quién está logueado
        public FormPermisos(string nivel, string idEmpleado)
        {
            InitializeComponent();
            _nivelUsuario = nivel;
            _idEmpleadoActual = idEmpleado;
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {
            // 1. LIMPIEZA TOTAL: Ocultamos y mandamos al fondo todo
            pnlDirector.Visible = false;
            pnlAnalista.Visible = false;
            pnlEmpleado.Visible = false;

            // 2. POSICIONAMIENTO UNIFICADO
            Point posicionGeneral = new Point(20, 80);
            Size tamanoGeneral = new Size(1030, 500);

            pnlDirector.Location = pnlAnalista.Location = pnlEmpleado.Location = posicionGeneral;
            pnlDirector.Size = pnlAnalista.Size = pnlEmpleado.Size = tamanoGeneral;

            switch (_nivelUsuario)
            {
                case "1": // DIRECTOR
                    lblTitulo.Text = "Historial Global de Permisos (Director)";
                    pnlDirector.Visible = true;
                    pnlDirector.BringToFront(); // Obligamos a que suba al primer nivel
                    CargarHistorialDirector();
                    break;

                case "2": // ANALISTA (Gerentes/Analistas RRHH)
                    lblTitulo.Text = "Bandeja de Aprobación (Analista)";
                    pnlAnalista.Visible = true;
                    pnlAnalista.BringToFront();
                    CargarColaAnalista();
                    break;

                case "3": // DESARROLLADORES / EMPLEADOS
                case "4":
                case "5":
                default:
                    lblTitulo.Text = "Mis Solicitudes de Permiso (Empleado)";
                    pnlEmpleado.Visible = true;
                    pnlEmpleado.BringToFront();
                    CargarHistorialEmpleado();
                    break;
            }
        }

        // ==========================================
        // LÓGICA NIVEL 1: DIRECTOR
        // ==========================================
        private void CargarHistorialDirector()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var historialCompleto = db.SolicitudPermiso
                                          .Include("Empleado")
                                          .Select(s => new
                                          {
                                              s.IdSolicitud,
                                              Empleado = s.Empleado.NombreCompleto,
                                              s.TipoPermiso,
                                              s.FechaSolicitud,
                                              s.EstadoAprobacion
                                          }).ToList();
                dgvDirector.DataSource = historialCompleto;
            }
        }

        // ==========================================
        // LÓGICA NIVEL 2: ANALISTA (COLA DE PRIORIDAD)
        // ==========================================
        private void CargarColaAnalista()
        {
            miColaPermisos = new ColaPrioridadPermisos();
            using (var db = new SistemaRRHHEntities())
            {
                var pendientes = db.SolicitudPermiso
                                   .Include("Empleado")
                                   .Where(s => s.EstadoAprobacion == "Pendiente")
                                   .ToList();

                foreach (var sol in pendientes)
                {
                    NodoPermiso nodo = new NodoPermiso
                    {
                        IdSolicitud = sol.IdSolicitud,
                        NombreEmpleado = sol.Empleado.NombreCompleto,
                        TipoPermiso = sol.TipoPermiso,
                        NivelPrioridad = sol.NivelPrioridad,
                        FechaSolicitud = sol.FechaSolicitud,
                        CantidadTiempo = sol.CantidadTiempo,
                        UnidadTiempo = sol.UnidadTiempo,
                        MotivoDetallado = sol.MotivoDetallado,
                        RutaComprobante = sol.RutaComprobante
                    };
                    miColaPermisos.Encolar(nodo); // Se ordenan solos
                }
            }

            // Cargamos la estructura ordenada al DataGridView
            dgvAnalista.DataSource = miColaPermisos.ObtenerListaParaGrid();
            ConfigurarBotonesGridAnalista();
        }

        private void ConfigurarBotonesGridAnalista()
        {
            // Solo creamos los botones si no existen
            if (!dgvAnalista.Columns.Contains("btnAprobar"))
            {
                DataGridViewButtonColumn btnAprobar = new DataGridViewButtonColumn();
                btnAprobar.Name = "btnAprobar";
                btnAprobar.HeaderText = "Aprobar";
                btnAprobar.Text = "✔ Aprobar";
                btnAprobar.UseColumnTextForButtonValue = true;
                btnAprobar.DefaultCellStyle.BackColor = Color.LightGreen;
                dgvAnalista.Columns.Add(btnAprobar);

                DataGridViewButtonColumn btnRechazar = new DataGridViewButtonColumn();
                btnRechazar.Name = "btnRechazar";
                btnRechazar.HeaderText = "Rechazar";
                btnRechazar.Text = "✖ Rechazar";
                btnRechazar.UseColumnTextForButtonValue = true;
                btnRechazar.DefaultCellStyle.BackColor = Color.LightCoral;
                dgvAnalista.Columns.Add(btnRechazar);
            }
        }

        private void dgvAnalista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // REGLA DE ORO DE LA COLA: Solo se puede procesar el índice 0 (El Frente)
            if (e.RowIndex != 0)
            {
                MessageBox.Show("Por reglas de la Cola de Prioridad, debe atender primero la solicitud más urgente (Fila 1).",
                                "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = "";
            if (dgvAnalista.Columns[e.ColumnIndex].Name == "btnAprobar") accion = "Aprobado";
            if (dgvAnalista.Columns[e.ColumnIndex].Name == "btnRechazar") accion = "Rechazado";

            if (accion != "")
            {
                // Desencolamos el elemento
                NodoPermiso procesado = miColaPermisos.Desencolar();

                using (var db = new SistemaRRHHEntities())
                {
                    var solicitudDb = db.SolicitudPermiso.Find(procesado.IdSolicitud);
                    solicitudDb.EstadoAprobacion = accion;
                    db.SaveChanges();
                }

                MessageBox.Show($"Solicitud de {procesado.NombreEmpleado} {accion.ToLower()}.", "Éxito");
                CargarColaAnalista(); // Refrescamos el grid
            }
        }

        // ==========================================
        // LÓGICA NIVEL 3: EMPLEADO NORMAL
        // ==========================================
        private void CargarHistorialEmpleado()
        {
            using (var db = new SistemaRRHHEntities())
            {
                var misPermisos = db.SolicitudPermiso
                                    .Where(s => s.IdEmpleado == _idEmpleadoActual)
                                    .OrderByDescending(s => s.FechaSolicitud)
                                    .Select(s => new
                                    {
                                        Tipo = s.TipoPermiso,
                                        Prioridad = s.NivelPrioridad,
                                        Fecha = s.FechaSolicitud,
                                        Tiempo = s.CantidadTiempo + " " + s.UnidadTiempo,
                                        Motivo = s.MotivoDetallado,
                                        Estado = s.EstadoAprobacion
                                    }).ToList();

                dgvEmpleado.DataSource = misPermisos;

                if (dgvEmpleado.Columns.Count > 0)
                {
                    dgvEmpleado.Columns["Tipo"].HeaderText = "Tipo de Permiso";
                    dgvEmpleado.Columns["Prioridad"].HeaderText = "Nivel";
                    dgvEmpleado.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
        }

        private void btnEnviarPermiso_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (cmbPrioridadEmp.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un nivel de prioridad.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivoEmp.Text) || txtMotivoEmp.Text.Length < 10)
            {
                MessageBox.Show("Por favor, escriba un motivo detallado (mínimo 10 caracteres).");
                return;
            }

            int prioridad = cmbPrioridadEmp.SelectedIndex + 1;

            try
            {
                using (var db = new SistemaRRHHEntities())
                {
                    SolicitudPermiso nueva = new SolicitudPermiso
                    {
                        IdEmpleado = _idEmpleadoActual,
                        TipoPermiso = "Permiso Nivel " + prioridad,
                        NivelPrioridad = prioridad,
                        FechaSolicitud = DateTime.Now,
                        EstadoAprobacion = "Pendiente",
                        CantidadTiempo = (int)numTiempoEmp.Value,
                        UnidadTiempo = cmbUnidadEmp.Text,
                        MotivoDetallado = txtMotivoEmp.Text,
                        RutaComprobante = null
                    };

                    db.SolicitudPermiso.Add(nueva);
                    db.SaveChanges();
                }

                MessageBox.Show("Solicitud enviada a RRHH con éxito.", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos tras enviar
                txtMotivoEmp.Clear();
                numTiempoEmp.Value = 1;

                CargarHistorialEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar la solicitud: " + ex.Message);
            }
        }
    }
}