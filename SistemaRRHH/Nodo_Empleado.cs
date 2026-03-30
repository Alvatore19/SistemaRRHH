using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaRRHH
{
    public class Nodo_Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public double Sueldo { get; set; }


        // Punteros del árbol
        public Nodo_Empleado Jefe { get; set; }
        public List<Nodo_Empleado> Subalternos { get; set; }

        public Nodo_Empleado(string id, string nombre, string puesto, double sueldo)
        {
            Id = id;
            Nombre = nombre;
            Puesto = puesto;
            Sueldo = sueldo; // <--- LO ASIGNAMOS
            Jefe = null;
            Subalternos = new List<Nodo_Empleado>();
        }

        // Magia para que el ComboBox muestre el texto bonito y no el nombre del objeto
        public override string ToString()
        {
            return Nombre + " - " + Puesto;
        }
    }
}


