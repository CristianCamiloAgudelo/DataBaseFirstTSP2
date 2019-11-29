using System;
using System.Collections.Generic;
using System.Text;

namespace TSP.Forms.Model
{
    public class Tarea
    {
        public long TareaId { get; set; }
        public string Nombre { get; set; }
        public int? MinutosLiderProyectoPlaneado { get; set; }
        public int? MinutosLiderPlaneacionPlaneado { get; set; }
        public int? MinutosLiderDesarrolloPlaneado { get; set; }
        public int? MinutosLiderCalidadPlaneado { get; set; }
        public int? MinutosLiderSoportePlaneado { get; set; }
        public int? MinutosTotalesPlaneados { get; set; }
        public int? MinutosLiderProyectoReales { get; set; }
        public int? MinutosLiderPlaneacionReales { get; set; }
        public int? MinutosLiderDesarrolloReales { get; set; }
        public int? MinutosLiderCalidadReales { get; set; }
        public int? MinutosLiderSoporteReales { get; set; }
        public int? MinutosTotalesReales { get; set; }
        public float? ValorPlaneado { get; set; }
        public float? ValorGanado { get; set; }
        public int? SemanaTerminacionPlaneada { get; set; }
        public int? SemanaTerminacionReal { get; set; }
        public long PlanGrupalId { get; set; }
        public long PlanIndividualId { get; set; }
    }
}
