using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITareas.Models.MisModelos;
using APITareas.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : Controller
    {

        private readonly ColaboradorServicios _repository;

        public ColaboradoresController(ColaboradorServicios repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SPColaboradorListarCLS>>> List()
        {
            return await _repository.GetAll();
        }
    }
}
