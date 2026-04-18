using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH
{
    // Cambiamos 'internal' por 'public'
    public class NodoPermiso
    {
        public int IdSolicitud { get; set; }
        public string NombreEmpleado { get; set; }
        public string TipoPermiso { get; set; }
        public int NivelPrioridad { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int CantidadTiempo { get; set; }
        public string UnidadTiempo { get; set; }
        public string MotivoDetallado { get; set; }
        public string RutaComprobante { get; set; }
        public NodoPermiso Siguiente { get; set; }
    }
}