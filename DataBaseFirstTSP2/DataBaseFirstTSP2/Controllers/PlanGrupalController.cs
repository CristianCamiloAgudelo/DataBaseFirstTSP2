using DataBaseFirstTSP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseFirstTSP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanGrupalController : ControllerBase
    {
        private LinkedList<EquipoDesarrollo> listaEquipo;
        private LinkedList<PlanGrupal> listaPlanGrupal;
        private LinkedList<Tarea> listaTareas;

        private readonly DataBaseFirstTSP2Context _context;

        public PlanGrupalController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/PlanGrupal
        [HttpGet]
        public LinkedList<PlanGrupal> GetPlanGrupal()
        {
            listaEquipo = new LinkedList<EquipoDesarrollo>();
            listaPlanGrupal = new LinkedList<PlanGrupal>();
            listaTareas = new LinkedList<Tarea>();

            _context.ChangeTracker.LazyLoadingEnabled = false;

            var listaPlanGrupalBd = _context.PlanGrupal.ToList();
            var listaEquipoDb = _context.EquipoDesarrollo.ToList();
            var listaTareasDb = _context.Tarea.ToList();

            foreach (var plan in listaPlanGrupalBd)
            {
                foreach (var equipo in listaEquipoDb)
                {
                    if (plan.EquipoDesarrolloId == equipo.EquipoDesarrolloId)
                    {
                        listaEquipo.AddLast(new EquipoDesarrollo
                        {
                            EquipoDesarrolloId = equipo.EquipoDesarrolloId,
                            Nombre = equipo.Nombre
                        });
                    }
                }

                foreach (var tarea in listaTareasDb)
                {
                    if (plan.PlanGrupalId == tarea.PlanGrupalId)
                    {
                        listaTareas.AddLast(new Tarea
                        {
                            TareaId = tarea.TareaId,
                            Nombre = tarea.Nombre,
                            MinutosLiderProyectoReales = tarea.MinutosLiderProyectoReales,
                            MinutosLiderPlaneacionReales = tarea.MinutosLiderPlaneacionReales,
                            MinutosLiderSoporteReales = tarea.MinutosLiderSoporteReales,
                            MinutosLiderCalidadReales = tarea.MinutosLiderCalidadReales,
                            MinutosLiderDesarrolloReales = tarea.MinutosLiderDesarrolloReales,
                            ValorGanado = tarea.ValorGanado,
                            MinutosTotalesReales = tarea.MinutosTotalesReales,
                            PlanGrupalId = tarea.PlanGrupalId,
                            PlanIndividualId = tarea.PlanIndividualId

                        }
                            );
                    }
                }
                listaPlanGrupal.AddLast(new PlanGrupal
                {
                    PlanGrupalId = plan.PlanGrupalId,
                    Nombre = plan.Nombre,
                    EquipoDesarrolloId = plan.EquipoDesarrolloId,
                    EquipoDesarrollo = listaEquipo.Last(),
                    Tarea = listaTareas

                }
                );
            }


            return listaPlanGrupal;
        }

        // GET: api/PlanGrupal/5
        [HttpGet("{id}")]
        public PlanGrupal GetPlanGrupal(long id)
        {
            listaEquipo = new LinkedList<EquipoDesarrollo>();
            listaTareas = new LinkedList<Tarea>();

            _context.ChangeTracker.LazyLoadingEnabled = false;

            var planGrupalBd = _context.PlanGrupal
          .SingleOrDefault(b => b.PlanGrupalId == id);


            if (planGrupalBd == null)
            {
                return null;
            }

            foreach (var item in _context.PlanGrupal.ToList())
            {
                if (planGrupalBd.EquipoDesarrolloId == item.EquipoDesarrolloId)
                {
                    listaEquipo.AddLast(new EquipoDesarrollo
                    {
                        EquipoDesarrolloId = item.EquipoDesarrolloId,
                        Nombre = item.Nombre
                    });
                }

                foreach (var tarea in _context.Tarea.ToList())
                {
                    if (item.PlanGrupalId == tarea.PlanGrupalId)
                    {
                        listaTareas.AddLast(new Tarea
                        {
                            TareaId = tarea.TareaId,
                            Nombre = tarea.Nombre,
                            MinutosLiderProyectoReales = tarea.MinutosLiderProyectoReales,
                            MinutosLiderPlaneacionReales = tarea.MinutosLiderPlaneacionReales,
                            MinutosLiderSoporteReales = tarea.MinutosLiderSoporteReales,
                            MinutosLiderCalidadReales = tarea.MinutosLiderCalidadReales,
                            MinutosLiderDesarrolloReales = tarea.MinutosLiderDesarrolloReales,
                            ValorGanado = tarea.ValorGanado,
                            MinutosTotalesReales = tarea.MinutosTotalesReales,
                            PlanGrupalId = tarea.PlanGrupalId,
                            PlanIndividualId = tarea.PlanIndividualId

                        }
                            );
                    }
                }

            }

            planGrupalBd.EquipoDesarrollo = listaEquipo.First();
            planGrupalBd.Tarea = listaTareas;

            return planGrupalBd;
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
