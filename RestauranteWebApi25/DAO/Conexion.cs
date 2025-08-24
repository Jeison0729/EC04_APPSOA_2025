using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Conexion
    {
        private string cadenaConexion;

        public Conexion()
        {
            cadenaConexion = "Server=SERVIDOR\\SQLEXPRESS;Database=Restaurante;Trusted_Connection=true;";
        }
        
        public SqlConnection GetConexion()
        {
            return new SqlConnection(cadenaConexion);

        }

    }
}
