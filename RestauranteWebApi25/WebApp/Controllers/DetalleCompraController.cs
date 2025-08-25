using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using DAO;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : ControllerBase
    {
        private readonly DetalleCompraDAO detalleCompraDAO = new DetalleCompraDAO();

        [HttpGet]
        public ActionResult<IEnumerable<DetalleCompraProveedor>> GetDetalleCompras()
        {
            var detalles = detalleCompraDAO.ListarDetalles();
            return Ok(detalles);
        }
    }
}
