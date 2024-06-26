using Backends.Data;
using Backends.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backends.Controllers
{
    [Route("api/tareas")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaController (ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTareas()
        {
            return Ok(await _tareaRepository.GetAllTareas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTGetTareaById(int id)
        {
            return Ok(await _tareaRepository.GetTareaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTarea([FromBody] Tarea tarea)
        {
            if (tarea == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created= await _tareaRepository.CreateTarea(tarea);

            return Created("created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(Tarea tarea)
        {
            if (tarea == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tareaRepository.UpdateTarea(tarea);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            await _tareaRepository.DeleteTarea(new Tarea { Id = id });
            return NoContent();
        }
    }
}
