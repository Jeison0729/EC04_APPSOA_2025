using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompraProveedor
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaModificacion { get; set; }

        public OrdenCompra OrdenCompra { get; set; }
        public Insumos Insumos { get; set; }
    }
}
