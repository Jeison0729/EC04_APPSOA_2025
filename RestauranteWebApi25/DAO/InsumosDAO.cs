using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class InsumosDAO
    {
        private Conexion conexion = new Conexion();

        public List<Insumos> ListarInsumos()
        {
            List<Insumos> insumos = new List<Insumos>();

            using (var con = conexion.GetConexion())
            {
                con.Open();
                string sql = @"
                    SELECT i.id, i.nombre, i.stock, i.id_categoria, i.fecha_modificacion,
                           c.id AS cat_id, c.nombre AS cat_nombre
                    FROM insumos i
                    LEFT JOIN categorias_insumos c ON i.id_categoria = c.id
                ";

                var comandoSQL = new SqlCommand(sql, con);
                var reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    var insumo = new Insumos
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Stock = reader.GetInt32(2),
                        IdCategoria = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                        FechaModificacion = reader.GetDateTime(4),
                        Categoria = reader.IsDBNull(5) ? null : new categorias_insumos
                        {
                            Id = reader.GetInt32(5),
                            Nombre = reader.GetString(6)
                        }
                    };

                    insumos.Add(insumo);
                }

                return insumos;
            }
        }
    }
}
