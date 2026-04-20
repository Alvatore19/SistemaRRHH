using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH
{
    public class Boleta
    {
        public string Mes { get; set; }
        public double Salario { get; set; }
        public double Bonos { get; set; }
        public double Descuentos { get; set; }
        public double TotalNeto { get { return (Salario + Bonos) - Descuentos; } } // Campo extra para la tabla
        public Boleta Siguiente { get; set; }

        public Boleta(string mes, double salario, double bonos, double descuentos)
        {
            Mes = mes;
            Salario = salario;
            Bonos = bonos;
            Descuentos = descuentos;
            Siguiente = null;
        }
    }
}
