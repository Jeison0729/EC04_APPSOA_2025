using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DetalleCompraDAO
    {
        private Conexion conexion = new Conexion();

        public List<DetalleCompraProveedor> ListarDetalles()
        {
            List<DetalleCompraProveedor> detalles = new List<DetalleCompraProveedor>();

            using (var con = conexion.GetConexion())
            {
                con.Open();

                string sql = @"
                    SELECT d.id, d.id_orden_compra, d.id_insumo, d.cantidad, d.precio_unit, d.total, d.fecha_modificacion,
                           i.id, i.nombre, i.stock, i.id_categoria, i.fecha_modificacion
                    FROM detalle_compra_proveedor d
                    INNER JOIN insumos i ON d.id_insumo = i.id
                ";

                SqlCommand comando = new SqlCommand(sql, con);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DetalleCompraProveedor detalle = new DetalleCompraProveedor
                    {
                        Id = reader.GetInt32(0),
                        IdOrdenCompra = reader.GetInt32(1),
                        IdInsumo = reader.GetInt32(2),
                        Cantidad = reader.GetInt32(3),
                        PrecioUnit = reader.GetDecimal(4),
                        Total = reader.GetDecimal(5),
                        FechaModificacion = reader.GetDateTime(6),

                        Insumos = new Insumos
                        {
                            Id = reader.GetInt32(7),
                            Nombre = reader.GetString(8),
                            Stock = reader.GetInt32(9),
                            IdCategoria = reader.IsDBNull(10) ? (int?)null : reader.GetInt32(10),
                            FechaModificacion = reader.GetDateTime(11)
                        }
                    };

                    detalles.Add(detalle);
                }
            }

            return detalles;
        }
    }
}
