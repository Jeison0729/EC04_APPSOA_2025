using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class OrdenCompraDAO
    {
        private Conexion conexion = new Conexion();

        public List<OrdenCompra> ListarOrdenes()
        {
            List<OrdenCompra> lista = new List<OrdenCompra>();

            using (var con = conexion.GetConexion())
            {
                con.Open();
                string sql = @"
                    SELECT o.id, o.id_proveedor, o.observaciones, o.monto_total, o.fecha_modificacion,
                           p.id, p.documento, p.nombres, p.telefono, p.direccion, p.correo, p.fecha_modificacion
                    FROM orden_compra o
                    INNER JOIN proveedores p ON o.id_proveedor = p.id
                ";

                SqlCommand comandoSQL = new SqlCommand(sql, con);
                SqlDataReader reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    var orden = new OrdenCompra
                    {
                        Id = reader.GetInt32(0),
                        IdProveedor = reader.GetInt32(1),
                        Observaciones = reader.IsDBNull(2) ? null : reader.GetString(2),
                        MontoTotal = reader.GetDecimal(3),
                        FechaModificacion = reader.GetDateTime(4),
                        Proveedor = new Proveedor
                        {
                            Id = reader.GetInt32(5),
                            Documento = reader.GetString(6),
                            Nombres = reader.GetString(7),
                            Telefono = reader.GetString(8),
                            Direccion = reader.GetString(9),
                            Correo = reader.GetString(10),
                            FechaModificacion = reader.GetDateTime(11)
                        }
                    };

                    lista.Add(orden);
                }
            }

            return lista;
        }
    }
}
