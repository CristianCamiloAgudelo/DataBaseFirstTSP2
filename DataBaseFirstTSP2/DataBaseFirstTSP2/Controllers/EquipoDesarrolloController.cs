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
    public class EquipoDesarrolloController : ControllerBase
    {
        private readonly DataBaseFirstTSP2Context _context;

        public EquipoDesarrolloController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }


        // GET: api/EquipoDesarrollo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoDesarrollo>>> GetEquipoDesarrollo()
        {
            return await _context.EquipoDesarrollo.ToListAsync();
        }

        // GET: api/EquipoDesarrollo/5
        [HttpGet("{id}")]
        public EquipoDesarrollo GetEquipoDesarrollo(long id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;

            var equipo = _context.EquipoDesarrollo
          .SingleOrDefault(b => b.EquipoDesarrolloId == id);

            if (equipo == null)
            {
                return null;
            }
           
            return equipo;
        }

        // PUT: api/EquipoDesarrollo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipoDesarrollo(long id, EquipoDesarrollo equipoDesarrollo)
        {
            if (id != equipoDesarrollo.EquipoDesarrolloId)
            {
                return BadRequest();
            }

            _context.Entry(equipoDesarrollo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoDesarrolloExists(id))
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

        // POST: api/EquipoDesarrollo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EquipoDesarrollo>> PostEquipoDesarrollo(EquipoDesarrollo equipoDesarrollo)
        {
            _context.EquipoDesarrollo.Add(equipoDesarrollo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipoDesarrollo", new { id = equipoDesarrollo.EquipoDesarrolloId }, equipoDesarrollo);
        }

        // DELETE: api/EquipoDesarrollo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipoDesarrollo>> DeleteEquipoDesarrollo(long id)
        {
            var equipoDesarrollo = await _context.EquipoDesarrollo.FindAsync(id);
            if (equipoDesarrollo == null)
            {
                return NotFound();
            }

            _context.EquipoDesarrollo.Remove(equipoDesarrollo);
            await _context.SaveChangesAsync();

            return equipoDesarrollo;
        }

        private bool EquipoDesarrolloExists(long id)
        {
            return _context.EquipoDesarrollo.Any(e => e.EquipoDesarrolloId == id);
        }
    }
}
