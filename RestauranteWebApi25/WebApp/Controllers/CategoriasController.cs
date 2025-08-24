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
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaDAO categoriaDAO;
        public CategoriasController()
        {
            categoriaDAO = new CategoriaDAO();
        }

        [HttpGet]
        public ActionResult<IEnumerable<categorias_insumos>> GetCategorias()
        {
            var categorias = categoriaDAO.ListarCategorias();
            return Ok(categorias);
        }
        
    }
}