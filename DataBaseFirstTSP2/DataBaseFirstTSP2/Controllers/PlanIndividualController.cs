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
    public class PlanIndividualController : ControllerBase
    {
        private readonly DataBaseFirstTSP2Context _context;

        public PlanIndividualController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/PlanIndividual
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanIndividual>>> GetPlanIndividual()
        {
            return await _context.PlanIndividual.ToListAsync();
        }

        // GET: api/PlanIndividual/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanIndividual>> GetPlanIndividual(long id)
        {
            var planIndividual = await _context.PlanIndividual.FindAsync(id);

            if (planIndividual == null)
            {
                return NotFound();
            }

            return planIndividual;
        }

        // PUT: api/PlanIndividual/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanIndividual(long id, PlanIndividual planIndividual)
        {
            if (id != planIndividual.PlanIndividualId)
            {
                return BadRequest();
            }

            _context.Entry(planIndividual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanIndividualExists(id))
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

        // POST: api/PlanIndividual
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlanIndividual>> PostPlanIndividual(PlanIndividual planIndividual)
        {
            _context.PlanIndividual.Add(planIndividual);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanIndividual", new { id = planIndividual.PlanIndividualId }, planIndividual);
        }

        // DELETE: api/PlanIndividual/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanIndividual>> DeletePlanIndividual(long id)
        {
            var planIndividual = await _context.PlanIndividual.FindAsync(id);
            if (planIndividual == null)
            {
                return NotFound();
            }

            _context.PlanIndividual.Remove(planIndividual);
            await _context.SaveChangesAsync();

            return planIndividual;
        }

        private bool PlanIndividualExists(long id)
        {
            return _context.PlanIndividual.Any(e => e.PlanIndividualId == id);
        }
    }
}
