using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataBaseFirstTSP2.Models
{
    [DataContract(IsReference=true)]
    public partial class Usuario
    {
        public Usuario()
        {
            PlanIndividual = new HashSet<PlanIndividual>();
        }

        public long UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Universidad { get; set; }
        public string Codigo { get; set; }
        public string Rol { get; set; }
        public long EquipoDesarrolloId { get; set; }

        public virtual EquipoDesarrollo EquipoDesarrollo { get; set; }
        public virtual ICollection<PlanIndividual> PlanIndividual { get; set; }
    }
}
