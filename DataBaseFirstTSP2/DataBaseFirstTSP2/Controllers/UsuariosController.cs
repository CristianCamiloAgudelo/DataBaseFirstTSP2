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
    public class UsuariosController : ControllerBase
    {
        private readonly DataBaseFirstTSP2Context _context;
        private LinkedList<Usuario> listUser;
        private LinkedList<EquipoDesarrollo> listEquipo;

        public UsuariosController(DataBaseFirstTSP2Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public LinkedList<Usuario> GetUsuario()
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;

            listUser = new LinkedList<Usuario>();
            listEquipo = new LinkedList<EquipoDesarrollo>();
            var listUserDb = _context.Usuario.ToList();
            var listaEquipoDb = _context.EquipoDesarrollo.ToList();

            foreach (var user in listUserDb)
            {
                foreach (var equipo in listaEquipoDb)
                {
                    if (user.EquipoDesarrolloId.Equals(equipo.EquipoDesarrolloId))
                    {
                        listEquipo.AddLast(new EquipoDesarrollo
                        {
                            EquipoDesarrolloId = equipo.EquipoDesarrolloId,
                            Nombre = equipo.Nombre
                        });
                    }
                }
                listUser.AddLast(new Usuario
                {
                    UsuarioId = user.UsuarioId,
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    Universidad = user.Universidad,
                    Codigo = user.Codigo,
                    Rol = user.Rol,
                    EquipoDesarrolloId = user.EquipoDesarrolloId,
                    EquipoDesarrollo = listEquipo.Last()

                });
            }

            return listUser;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public Usuario GetUsuario(long id)
        {
            listEquipo = new LinkedList<EquipoDesarrollo>();

            _context.ChangeTracker.LazyLoadingEnabled = false;

            var usuario = _context.Usuario
          .SingleOrDefault(b => b.UsuarioId == id);


            if (usuario == null)
            {
                return null;
            }

            foreach (var item in _context.EquipoDesarrollo.ToList())
            {
                if (usuario.EquipoDesarrolloId == item.EquipoDesarrolloId)
                {
                    listEquipo.AddLast(new EquipoDesarrollo
                    {
                        EquipoDesarrolloId = item.EquipoDesarrolloId,
                        Nombre = item.Nombre
                    });
                }

            }

            usuario.EquipoDesarrollo = listEquipo.First();

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(long id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
