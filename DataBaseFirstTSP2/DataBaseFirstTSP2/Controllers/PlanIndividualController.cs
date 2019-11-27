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
    public class PlanIndividualController : ControllerBase
    {
        private LinkedList<Usuario> listaUsuario;
        private LinkedList<PlanIndividual> listaIndividual;

        private readonly DataBaseFirstTSP2Context _context;

        public PlanIndividualController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/PlanIndividual
        [HttpGet]
        public LinkedList<PlanIndividual> GetPlanIndividual()
        {
            listaIndividual = new LinkedList<PlanIndividual>();
            listaUsuario = new LinkedList<Usuario>();

            var listaIndividualBd = _context.PlanIndividual.ToList();
            var listaUsuarioBd = _context.Usuario.ToList();

            foreach (var plan in listaIndividualBd)
            {
                foreach (var user in listaUsuarioBd)
                {
                    if (plan.UsuarioId == user.UsuarioId)
                    {
                        listaUsuario.AddLast(new Usuario
                        {
                            UsuarioId = user.UsuarioId,
                            Nombre = user.Nombre,
                            Apellido = user.Apellido,
                            Universidad = user.Universidad,
                            Codigo = user.Codigo,
                            Rol = user.Rol,
                            EquipoDesarrolloId = user.EquipoDesarrolloId
                        });
                    }
                    
                }
                listaIndividual.AddLast(new PlanIndividual
                {
                    PlanIndividualId = plan.PlanIndividualId,
                    Nombre = plan.Nombre,
                    UsuarioId = plan.UsuarioId,
                    Usuario = listaUsuario.Last()
                });
            }

            return listaIndividual;
        }

        // GET: api/PlanIndividual/5
        [HttpGet("{id}")]
        public PlanIndividual GetPlanIndividual(long id)
        {
            listaIndividual = new LinkedList<PlanIndividual>();
            

            _context.ChangeTracker.LazyLoadingEnabled = false;

            var planIndividualBd = _context.PlanIndividual
          .SingleOrDefault(b => b.PlanIndividualId == id);

            var usuarioBd = _context.Usuario.ToList();

            if (planIndividualBd == null)
            {
                return null;
            }

            foreach (var plan in _context.PlanIndividual)
            {
                foreach (var user in usuarioBd)
                {
                    if (planIndividualBd.UsuarioId == user.UsuarioId)
                    {
                        listaUsuario = new LinkedList<Usuario>();
                        listaUsuario.AddLast(new Usuario
                        {
                            UsuarioId = user.UsuarioId,
                            Nombre = user.Nombre,
                            Apellido = user.Apellido,
                            Universidad = user.Universidad,
                            Codigo = user.Codigo,
                            Rol = user.Rol,
                            EquipoDesarrolloId = user.EquipoDesarrolloId,

                        });
                    }
                }
                if (plan.PlanIndividualId == planIndividualBd.PlanIndividualId)
                {
                    listaIndividual.AddLast(new PlanIndividual
                    {
                        PlanIndividualId = plan.PlanIndividualId,
                        Nombre = plan.Nombre,
                        UsuarioId = plan.UsuarioId,
                        Usuario = listaUsuario.First()
                    });
                }
            }

            return listaIndividual.Last();
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
