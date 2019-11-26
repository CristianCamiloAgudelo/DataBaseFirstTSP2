using System;
using System.Collections.Generic;

namespace DataBaseFirstTSP2.Models
{
    public partial class PlanIndividual
    {
        public PlanIndividual()
        {
            Tarea = new HashSet<Tarea>();
        }

        public long PlanIndividualId { get; set; }
        public string Nombre { get; set; }
        public long UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
