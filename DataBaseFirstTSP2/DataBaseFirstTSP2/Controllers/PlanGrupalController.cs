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
    public class PlanGrupalController : ControllerBase
    {
        private readonly DataBaseFirstTSP2Context _context;

        public PlanGrupalController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/PlanGrupal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanGrupal>>> GetPlanGrupal()
        {
            return await _context.PlanGrupal.ToListAsync();
        }

        // GET: api/PlanGrupal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanGrupal>> GetPlanGrupal(long id)
        {
            var planGrupal = await _context.PlanGrupal.FindAsync(id);

            if (planGrupal == null)
            {
                return NotFound();
            }

            return planGrupal;
        }

        // PUT: api/PlanGrupal/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanGrupal(long id, PlanGrupal planGrupal)
        {
            if (id != planGrupal.PlanGrupalId)
            {
                return BadRequest();
            }

            _context.Entry(planGrupal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanGrupalExists(id))
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

        // POST: api/PlanGrupal
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlanGrupal>> PostPlanGrupal(PlanGrupal planGrupal)
        {
            _context.PlanGrupal.Add(planGrupal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanGrupal", new { id = planGrupal.PlanGrupalId }, planGrupal);
        }

        // DELETE: api/PlanGrupal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanGrupal>> DeletePlanGrupal(long id)
        {
            var planGrupal = await _context.PlanGrupal.FindAsync(id);
            if (planGrupal == null)
            {
                return NotFound();
            }

            _context.PlanGrupal.Remove(planGrupal);
            await _context.SaveChangesAsync();

            return planGrupal;
        }

        private bool PlanGrupalExists(long id)
        {
            return _context.PlanGrupal.Any(e => e.PlanGrupalId == id);
        }
    }
}
