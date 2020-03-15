using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace Pruebas
{
    public class TestWebServiceIndividual
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRespuestaCorrecta()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/PlanIndividual/1";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.OK, json.StatusCode);
        }

        [Test]
        public void TestRespuestaSinResultados()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/PlanIndividual/9";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.NoContent, json.StatusCode);
        }

        [Test]
        public void TestRespuestaIncorrecta()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/PlanIndividual/A";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, json.StatusCode);
        }

        [Test]
        public void TestCompararJson()
        {
            string Textojson = "{\"planGrupalId\":1,\"nombre\":\"Plan Grupal Grupo 1\",\"equipoDesarrolloId\":1,\"equipoDesarrollo\":{\"equipoDesarrolloId\":1,\"nombre\":\"Plan Grupal Grupo 1\",\"planGrupal\":[],\"usuario\":[]},\"tarea\":[{\"tareaId\":1,\"nombre\":\"Reunion Coordinacion Semanal\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":150,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":150,\"valorPlaneado\":5,\"valorGanado\":5,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":1,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":2,\"nombre\":\"Caso de uso 1\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":1,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":3,\"nombre\":\"Caso de uso 2\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":2,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":4,\"nombre\":\"Caso de uso 3\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":3,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":5,\"nombre\":\"Caso de uso 4\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":4,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":6,\"nombre\":\"Caso de uso 5\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":5,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":7,\"nombre\":\"Reunion Coordinacion Semanal 2\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":150,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":150,\"valorPlaneado\":5,\"valorGanado\":5,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":2,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":8,\"nombre\":\"Especificacion Caso de uso 1\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":1,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":9,\"nombre\":\"Especificacion Caso de uso 2\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":2,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":10,\"nombre\":\"Especificacion Caso de uso 3\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":3,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":11,\"nombre\":\"Especificacion Caso de uso 4\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":4,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":12,\"nombre\":\"Especificacion Caso de uso 5\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":5,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":13,\"nombre\":\"Mockup Caso de uso 1\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":1,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":14,\"nombre\":\"Mockup Caso de uso 2\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":2,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":15,\"nombre\":\"Mockup Caso de uso 3\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":3,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":16,\"nombre\":\"Mockup Caso de uso 4\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":4,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":17,\"nombre\":\"Mockup Caso de uso 5\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":5,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":18,\"nombre\":\"Inspeccion Caso de uso 1\",\"minutosLiderProyectoPlaneado\":30,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":30,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":1,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":19,\"nombre\":\"Inspeccion Caso de uso 2\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":30,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":30,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":2,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":20,\"nombre\":\"Inspeccion Caso de uso 3\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":30,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":30,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":3,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":21,\"nombre\":\"Inspeccion Caso de uso 4\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":30,\"minutosLiderSoportePlaneado\":0,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":30,\"minutosLiderSoporteReales\":0,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":4,\"planGrupal\":null,\"planIndividual\":null},{\"tareaId\":22,\"nombre\":\"Inspeccion Caso de uso 5\",\"minutosLiderProyectoPlaneado\":0,\"minutosLiderPlaneacionPlaneado\":0,\"minutosLiderDesarrolloPlaneado\":0,\"minutosLiderCalidadPlaneado\":0,\"minutosLiderSoportePlaneado\":30,\"minutosTotalesPlaneados\":30,\"minutosLiderProyectoReales\":0,\"minutosLiderPlaneacionReales\":0,\"minutosLiderDesarrolloReales\":0,\"minutosLiderCalidadReales\":0,\"minutosLiderSoporteReales\":30,\"minutosTotalesReales\":30,\"valorPlaneado\":2,\"valorGanado\":2,\"semanaTerminacionPlaneada\":1,\"semanaTerminacionReal\":null,\"planGrupalId\":1,\"planIndividualId\":5,\"planGrupal\":null,\"planIndividual\":null}]}";
            JToken esperado = JToken.Parse(Textojson);
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/PlanIndividual/1";
            var json = new WebClient().DownloadString(requestUri);
            JToken jsonActual = JToken.Parse(json);
            Assert.AreEqual(jsonActual, esperado);

        }
    }
}