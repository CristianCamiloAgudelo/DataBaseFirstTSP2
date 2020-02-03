using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TSP.Forms.Model;

namespace Pruebas
{
    public class TestConsumirWebServices
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConsultarPlanGrupalPorId()
        {
            string nombreEsperado = "";
            int equipoDesarrolloIdEsperado;

            string nombreReal = "";
            long equipoDesarrolloIdReal;

            var json = new WebClient().DownloadString("https://databasefirsttsp3.azurewebsites.net/api/plangrupal/1");
            var plangrupals = JsonConvert.DeserializeObject<PlanGrupal>(json);

            nombreReal = plangrupals.Nombre;
            equipoDesarrolloIdReal = plangrupals.EquipoDesarrolloId;

            nombreEsperado = "Plan Grupal Grupo 1";
            equipoDesarrolloIdEsperado = 1;


            Assert.AreEqual(equipoDesarrolloIdReal, equipoDesarrolloIdEsperado);
            Assert.AreEqual(nombreEsperado, nombreReal);
        }

        
    }
}
