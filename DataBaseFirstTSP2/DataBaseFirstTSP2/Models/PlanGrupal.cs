using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataBaseFirstTSP2.Models
{
    [DataContract(IsReference = true)]
    public partial class PlanGrupal
    {
        public PlanGrupal()
        {
            Tarea = new HashSet<Tarea>();
        }

        public long PlanGrupalId { get; set; }
        public string Nombre { get; set; }
        public long EquipoDesarrolloId { get; set; }

        public DateTime fechaDeInicio { get; set; }
        public virtual EquipoDesarrollo EquipoDesarrollo { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
