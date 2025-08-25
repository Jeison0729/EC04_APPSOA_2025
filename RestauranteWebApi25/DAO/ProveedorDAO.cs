using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class ProveedorDAO
    {
        private Conexion conexion = new Conexion();

        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (var con = conexion.GetConexion())
            {
                con.Open();
                string sql = @"SELECT id, documento, nombres, telefono, direccion, correo, fecha_modificacion FROM proveedores";
                var comandoSQL = new SqlCommand(sql, con);
                var reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    Proveedor proveedor = new Proveedor
                    {
                        Id = reader.GetInt32(0),
                        Documento = reader.GetString(1),
                        Nombres = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Direccion = reader.GetString(4),
                        Correo = reader.GetString(5),
                        FechaModificacion = reader.GetDateTime(6)
                    };
                    lista.Add(proveedor);
                }
            }

            return lista;
        }
    }
}
