using System;
using System.Collections.Generic;

namespace DataBaseFirstTSP2.Models
{
    public partial class EquipoDesarrollo
    {
        public EquipoDesarrollo()
        {
            PlanGrupal = new HashSet<PlanGrupal>();
            Usuario = new HashSet<Usuario>();
        }

        public long EquipoDesarrolloId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PlanGrupal> PlanGrupal { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
