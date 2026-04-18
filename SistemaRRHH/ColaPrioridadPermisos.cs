using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH
{
    public class ColaPrioridadPermisos
    {
        private NodoPermiso frente;

        public List<NodoPermiso> ObtenerListaParaGrid()
        {
            List<NodoPermiso> lista = new List<NodoPermiso>();
            NodoPermiso actual = frente;

            // Recorremos la cola enlazada desde el frente hasta el final
            while (actual != null)
            {
                lista.Add(actual);
                actual = actual.Siguiente;
            }
            return lista; // Usamos List<> solo para pasarlo a la pantalla, la lógica sigue siendo de Nodos.
        }

        public void Encolar(NodoPermiso nuevoNodo)
        {
            if (frente == null || nuevoNodo.NivelPrioridad < frente.NivelPrioridad)
            {
                nuevoNodo.Siguiente = frente;
                frente = nuevoNodo;
            }
            else
            {
                NodoPermiso actual = frente;

                while (actual.Siguiente != null && actual.Siguiente.NivelPrioridad <= nuevoNodo.NivelPrioridad)
                {
                    actual = actual.Siguiente;
                }

                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }

        public NodoPermiso Desencolar()
        {
            if (frente == null) return null;

            NodoPermiso temp = frente;
            frente = frente.Siguiente;
            return temp;
        }

        public NodoPermiso VerFrente()
        {
            return frente;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }
    }
}
