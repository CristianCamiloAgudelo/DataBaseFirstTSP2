using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using TSP.Forms.Model;

namespace Pruebas
{
    public class TestConsumirWebServicesIndividual
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestConsultarPlanIndividualPorId()
        {
            string nombreEsperado = "";
            int equipoDesarrolloIdEsperado;

            string nombreReal = "";
            long equipoDesarrolloIdReal;

            var json = new WebClient().DownloadString("https://databasefirsttsp3.azurewebsites.net/api/planindividual/1");
            var planindividualss = JsonConvert.DeserializeObject<PlanIndividual>(json);

            nombreReal = planindividualss.Nombre;
            equipoDesarrolloIdReal = planindividualss.EquipoDesarrolloId;

            nombreEsperado = "Plan Individual Lider Planeacion";
         


            Assert.AreEqual(nombreEsperado, nombreReal);
        }

        [Test]
        public void TestConsultarPlanIndividualNoExistente()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/planindividual/20";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.NoContent, json.StatusCode);

        }


    }
}
