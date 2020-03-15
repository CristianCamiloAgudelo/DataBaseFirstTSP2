using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBaseFirstTSP2.Models;

namespace DataBaseFirstTSP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly DataBaseFirstTSP2Context _context;

        public TareasController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTarea()
        {
            return await _context.Tarea.ToListAsync();
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(long id)
        {
            var tarea = await _context.Tarea.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }

        // PUT: api/Tareas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(long id, Tarea tarea)
        {
            if (id != tarea.TareaId)
            {
                return BadRequest();
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tareas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            _context.Tarea.Add(tarea);
            Tarea _tarea = new Tarea
            {
                TareaId = tarea.TareaId,
                Nombre = tarea.Nombre,
                MinutosLiderProyectoPlaneado = tarea.MinutosLiderProyectoPlaneado,
                MinutosLiderPlaneacionPlaneado = tarea.MinutosLiderPlaneacionPlaneado,
                MinutosLiderDesarrolloPlaneado = tarea.MinutosLiderDesarrolloPlaneado,
                MinutosLiderCalidadPlaneado = tarea.MinutosLiderCalidadPlaneado,
                MinutosLiderSoportePlaneado = tarea.MinutosLiderSoportePlaneado,

                MinutosLiderProyectoReales = tarea.MinutosLiderProyectoReales,
                MinutosLiderPlaneacionReales = tarea.MinutosLiderPlaneacionReales,
                MinutosLiderSoporteReales = tarea.MinutosLiderSoporteReales,
                MinutosLiderCalidadReales = tarea.MinutosLiderCalidadReales,
                MinutosLiderDesarrolloReales = tarea.MinutosLiderDesarrolloReales,

                ValorPlaneado = tarea.ValorPlaneado,
                ValorGanado = tarea.ValorGanado,
                MinutosTotalesPlaneados = tarea.MinutosTotalesPlaneados,
                MinutosTotalesReales = tarea.MinutosTotalesReales,
                PlanGrupalId = tarea.PlanGrupalId,
                PlanIndividualId = tarea.PlanIndividualId,
                SemanaTerminacionPlaneada = tarea.SemanaTerminacionPlaneada
            };

            await _context.SaveChangesAsync();



            return CreatedAtAction("GetTarea", new { id = _tarea.TareaId }, _tarea);
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarea>> DeleteTarea(long id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();

            return tarea;
        }

        private bool TareaExists(long id)
        {
            return _context.Tarea.Any(e => e.TareaId == id);
        }
    }
}
