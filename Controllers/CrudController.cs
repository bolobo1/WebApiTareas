using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APITareas.Models.MisModelos;
using APITareas.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITareas.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : Controller {

        private readonly TareasServicios _repository;

        public CrudController(TareasServicios repository) {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Listar tareas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SPTareasListarCLS>>> List() 
        {
            try
            {   
                return await _repository.GetAll();
            }
            catch(InvalidCastException e)
            {
                throw new Exception("Error: Error en listar "+e);
            }
        }

        // GET api/values/5
        /// <summary>
        /// Listar tareas por id
        /// </summary>
        [HttpGet("{TAREAS_ID}")]
        public async Task<ActionResult<SPTareasListarIdCLS>> Get(int TAREAS_ID) 
        {
            try
            {
                var response = await _repository.GetById(TAREAS_ID);
                if (response == null) { return NotFound(); }
                return response;
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Error: Error en listar " + e);
            }
        }

        // POST api/values
        /// <summary>
        /// Agregar una tarea
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> Post([FromBody] SPTareaCreateCLS value) 
        {
            HttpResponseMessage MensajeRespuesta;
            try
            {
                
                if (value is null)
                {
                    return StatusCodes.Status400BadRequest;
                }
                else
                {
                    int TareaGuardar = await _repository.Insert(value);
                    if (TareaGuardar >= 1)
                    {
                        return StatusCodes.Status201Created;
                    }
                    else
                    {
                        return StatusCodes.Status500InternalServerError;
                    }
                }
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Error: Error en listar " + e);
            }
        }



        // PUT api/values/5
        /// <summary>
        /// Editar Tareas
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut("{TAREAS_ID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> Put(int TAREAS_ID, [FromBody] SPTareaUpdate value) 
        {
            HttpResponseMessage MensajeRespuesta;
            try
            {
                if(value is null) 
                {
                     return StatusCodes.Status400BadRequest;
                }
                else 
                {
                    int TareaModificar =  await _repository.Update(value);
                    if (TareaModificar >= 1)
                    {
                        return StatusCodes.Status201Created;
                    }
                    else
                    {
                        return StatusCodes.Status500InternalServerError;
                    }
                }
                
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Error: Error en listar " + e);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{TAREAS_ID}")]
        public async Task Delete(int TAREAS_ID) 
        {
            try
            {
                await _repository.DeleteById(TAREAS_ID);
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Error: Error en listar " + e);
            }
        }
    }
}
