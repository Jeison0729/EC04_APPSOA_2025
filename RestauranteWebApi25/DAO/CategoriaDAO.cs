using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class CategoriaDAO
    {
        private Conexion conexion = new Conexion();

        public List<categorias_insumos> ListarCategorias()
        {
            List<categorias_insumos> categorias = new List<categorias_insumos>();
            using (var con = conexion.GetConexion()) {
                con.Open();
                var sql = @"SELECT id, nombre FROM categorias_insumos";
                var comandoSQL = new SqlCommand(sql, con);
                var reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    categorias_insumos categoria = new categorias_insumos
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    };
                    categorias.Add(categoria);
                }
            }
            return categorias;
        }
    }
}
