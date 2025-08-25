using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string Observaciones { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}
