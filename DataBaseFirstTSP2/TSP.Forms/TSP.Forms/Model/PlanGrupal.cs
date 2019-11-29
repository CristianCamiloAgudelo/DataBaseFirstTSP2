using System;
using System.Collections.Generic;
using System.Text;

namespace TSP.Forms.Model
{
    public class PlanGrupal
    {
        public long PlanGrupalId { get; set; }
        public string Nombre { get; set; }
        public long EquipoDesarrolloId { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
