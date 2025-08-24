using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using DAO;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly InsumosDAO insumosDAO = new InsumosDAO();

        [HttpGet]
        public ActionResult<IEnumerable<Insumos>> GetInsumos() {
            var insumos = insumosDAO.ListarInsumos();
            return Ok(insumos);
        }
    }
    
}