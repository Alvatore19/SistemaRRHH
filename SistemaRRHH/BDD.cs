using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace SistemaRRHH
{


    public class BDD
    {
        private string conexion = "";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(conexion);
        }
    }
}
