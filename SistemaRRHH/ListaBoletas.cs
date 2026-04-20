using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH
{
    public class ListaBoletas
    {
        public Boleta cabeza;

        public void Agregar(string mes, double salario, double bonos, double descuentos)
        {
            Boleta nueva = new Boleta(mes, salario, bonos, descuentos);

            if (cabeza == null)
            {
                cabeza = nueva;
            }
            else
            {
                Boleta actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nueva;
            }
        }

        // ¡Este método es clave para poder pasar tu lista al DataGridView!
        public List<Boleta> ObtenerListaParaGrid()
        {
            List<Boleta> lista = new List<Boleta>();
            Boleta actual = cabeza;
            while (actual != null)
            {
                lista.Add(actual);
                actual = actual.Siguiente;
            }
            return lista;
        }
    }
}
