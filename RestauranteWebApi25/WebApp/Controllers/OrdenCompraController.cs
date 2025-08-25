using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using DAO;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();

        [HttpGet]
        public ActionResult<IEnumerable<OrdenCompra>> GetOrdenesCompra()
        {
            var ordenes = ordenCompraDAO.ListarOrdenes();
            return Ok(ordenes);
        }
    }
}
