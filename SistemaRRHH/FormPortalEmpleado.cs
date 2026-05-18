using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
                                        Tiempo = s.CantidadHoras + " hrs", 
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Verificar que haya datos en el DataGridView de boletas
            if (dgvBoletas.Rows.Count == 0)
            {
                MessageBox.Show("No hay boletas de pago para imprimir.", "Información",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener la boleta seleccionada o la primera por defecto
            int rowIndex = dgvBoletas.CurrentRow?.Index ?? 0;

            // Crear el documento de impresión
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) => PrintBoletaPago(ev, rowIndex);

            // Mostrar vista previa antes de imprimir (opcional)
            PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };

            if (printPreview.ShowDialog() == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDocument
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void PrintBoletaPago(PrintPageEventArgs e, int rowIndex)
        {
            // Configurar fuentes y estilos
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font subtituloFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10, FontStyle.Regular);
            Font negritaFont = new Font("Arial", 10, FontStyle.Bold);

            // Márgenes y posiciones
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float yPos = topMargin;
            float lineHeight = normalFont.GetHeight(e.Graphics) + 5;

            // Título de la empresa
            string empresa = "SISTEMA RRHH - BOLETA DE PAGO";
            e.Graphics.DrawString(empresa, tituloFont, Brushes.DarkBlue,
                                 leftMargin + (e.MarginBounds.Width - e.Graphics.MeasureString(empresa, tituloFont).Width) / 2, yPos);
            yPos += tituloFont.GetHeight(e.Graphics) + 10;

            // Línea separadora
            e.Graphics.DrawLine(Pens.DarkBlue, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 10;

            // Datos del empleado
            e.Graphics.DrawString("DATOS DEL EMPLEADO", subtituloFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight + 5;

            e.Graphics.DrawString("Nombre:", negritaFont, Brushes.Black, leftMargin + 20, yPos);
            e.Graphics.DrawString(txtNombre.Text, normalFont, Brushes.Black, leftMargin + 120, yPos);
            yPos += lineHeight;

            e.Graphics.DrawString("DUI:", negritaFont, Brushes.Black, leftMargin + 20, yPos);
            e.Graphics.DrawString(txtDui.Text, normalFont, Brushes.Black, leftMargin + 120, yPos);
            yPos += lineHeight;

            e.Graphics.DrawString("Cargo:", negritaFont, Brushes.Black, leftMargin + 20, yPos);
            e.Graphics.DrawString(txtCargo.Text, normalFont, Brushes.Black, leftMargin + 120, yPos);
            yPos += lineHeight + 10;

            // Período de pago
            if (dgvBoletas.Rows.Count > rowIndex)
            {
                string periodo = dgvBoletas.Rows[rowIndex].Cells[0].Value?.ToString() ?? "N/A";
                e.Graphics.DrawString("PERÍODO DE PAGO", subtituloFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight + 5;
                e.Graphics.DrawString("Período:", negritaFont, Brushes.Black, leftMargin + 20, yPos);
                e.Graphics.DrawString(periodo, normalFont, Brushes.Black, leftMargin + 120, yPos);
                yPos += lineHeight + 10;
            }

            // Línea separadora
            e.Graphics.DrawLine(Pens.DarkBlue, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 10;

            // Detalle de pagos
            e.Graphics.DrawString("DETALLE DE PAGOS", subtituloFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight + 5;

            // Conceptos (puedes ajustar según las columnas reales de tu DataGridView)
            if (dgvBoletas.Rows.Count > rowIndex)
            {
                // Asumiendo que tienes columnas: Período, Salario Base, Horas Extra, Deducciones, Total
                string[] conceptos = { "Salario Base", "Horas Extra", "Deducciones", "Total Neto" };
                string[] valores = new string[4];

                for (int i = 0; i < 4; i++)
                {
                    if (i + 1 < dgvBoletas.Columns.Count)
                    {
                        valores[i] = dgvBoletas.Rows[rowIndex].Cells[i + 1].Value?.ToString() ?? "0";
                    }
                    else
                    {
                        valores[i] = "0";
                    }
                }

                for (int i = 0; i < conceptos.Length; i++)
                {
                    e.Graphics.DrawString(conceptos[i] + ":", negritaFont, Brushes.Black, leftMargin + 20, yPos);

                    // Alinear los valores a la derecha
                    string valor = "$" + valores[i];
                    SizeF textSize = e.Graphics.MeasureString(valor, normalFont);
                    e.Graphics.DrawString(valor, normalFont, Brushes.Black,
                                        e.MarginBounds.Right - textSize.Width - 20, yPos);

                    yPos += lineHeight;

                    // Línea punteada para cada concepto
                    e.Graphics.DrawLine(new Pen(Brushes.Gray, 0.5f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot },
                                      leftMargin + 20, yPos - 3, e.MarginBounds.Right - 20, yPos - 3);
                }
            }

            yPos += 20;

            // Línea separadora final
            e.Graphics.DrawLine(Pens.DarkBlue, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 10;

            // Fecha de emisión
            e.Graphics.DrawString("Fecha de emisión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                 normalFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight;

            // Firma digital
            e.Graphics.DrawString("_________________________", normalFont, Brushes.Black,
                                 leftMargin + (e.MarginBounds.Width - 200) / 2, yPos + 40);
            e.Graphics.DrawString("Firma del Empleado", normalFont, Brushes.Black,
                                 leftMargin + (e.MarginBounds.Width - 200) / 2 + 20, yPos + 60);

            // Nota al pie
            yPos = e.MarginBounds.Bottom - 30;
            e.Graphics.DrawString("Este documento es una representación digital de la boleta de pago.",
                                 new Font("Arial", 8), Brushes.Gray, leftMargin, yPos);

            // Indicar que no hay más páginas
            e.HasMorePages = false;
        }

    }
}
