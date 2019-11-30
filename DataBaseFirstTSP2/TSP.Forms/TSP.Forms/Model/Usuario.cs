using System;
using System.Collections.Generic;
using System.Text;

namespace TSP.Forms.Model
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Universidad { get; set; }
        public string Codigo { get; set; }
        public string Rol { get; set; }
        public string FotoPerfil { get; set; }

    }
}
