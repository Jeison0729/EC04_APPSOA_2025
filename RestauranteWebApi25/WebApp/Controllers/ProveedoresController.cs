using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using DAO;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ProveedorDAO proveedorDAO = new ProveedorDAO();

        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> GetProveedores()
        {
            var proveedores = proveedorDAO.ListarProveedores();
            return Ok(proveedores);
        }
    }
}
