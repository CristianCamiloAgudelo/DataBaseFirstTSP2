using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace Pruebas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestRespuestaCorrecta()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/equipoDesarrollo/1";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.OK, json.StatusCode);
        }

        [Test]
        public void TestRespuestaSinResultados()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/equipoDesarrollo/9";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.NoContent, json.StatusCode);
        }

        [Test]
        public void TestRespuestaIncorrecta()
        {
            var httpClient = new HttpClient();
            string requestUri = "https://databasefirsttsp3.azurewebsites.net/api/equipoDesarrollo/A";
            var json = httpClient.GetAsync(requestUri).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, json.StatusCode);
        }
    }
}