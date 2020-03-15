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

    }
}