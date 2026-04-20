using System;
using System.Collections.Generic;

namespace SistemaRRHH
{
    public class AsistenciaHashO1
    {
        private Dictionary<string, Asistencia> tabla = new Dictionary<string, Asistencia>();

        private string Key(string idEmpleado, DateTime fecha)
        {
            return $"{idEmpleado}_{fecha:yyyyMMdd}";
        }

        public void Guardar(Asistencia a)
        {
            tabla[Key(a.IdEmpleado, a.Fecha)] = a;
        }

        public Asistencia Obtener(string idEmpleado, DateTime fecha)
        {
            string k = Key(idEmpleado, fecha);

            if (tabla.ContainsKey(k))
                return tabla[k];

            return null;
        }

        public List<Asistencia> Listar()
        {
            return new List<Asistencia>(tabla.Values);
        }
    }
}