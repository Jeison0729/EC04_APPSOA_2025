using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


namespace DAO
{
    public class InsumosDAO
    {
        private string cadenaConexion;

        private Conexion conexion = new Conexion();

        public InsumosDAO(String cadena)
        {
            this.cadenaConexion = cadena;
        }

        public List<Insumos> ListarInsumos()
        {
            List<Insumos> insumos = new List<Insumos>();
            using (var con = conexion.GetConexion())
            {
                con.Open();
                var comandoSQL = new SqlCommand("SELECT * FROM insumos", con);
                var reader = comandoSQL.ExecuteReader();
                while (reader.Read())
                {
                    Insumos objInsumos = new Insumos();
                    objInsumos.Id = reader.GetInt32(0);
                    objInsumos.Nombre = reader.GetString(1);
                    objInsumos.Stock = reader.GetInt32(2);
                    objInsumos.IdCategoria = reader.GetInt32(3);
                    objInsumos.FechaModificacion = reader.GetDateTime(4);
                    insumos.Add(objInsumos);
                }
                return insumos;
            }
        }
    }
}
