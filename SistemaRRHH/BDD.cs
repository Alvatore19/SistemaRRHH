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
        private string conexion = "server=zam72y.h.filess.io;port=61002;database=RRHH_fightcryup;user=RRHH_fightcryup;password=0b0a073b1efdc49f54b1db62c00d06e5c7a1142f;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(conexion);
        }
    }
}
