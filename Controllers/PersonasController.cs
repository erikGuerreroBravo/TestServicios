
using Api.DsiCode.Principal.Infraestructura;
using Api.DsiCode.Principal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.DsiCode.Principal.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly IPersonaServices services;
        public PersonasController()
        {
            services = new PersonaServicces();       
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll() 
        {
            return Ok(services.GetPersonas());
        }

        [HttpGet]
        [Route("dinamic/{nombre}")]
        public IHttpActionResult Get(string nombre) 
        {
            return Ok(services.GetPersonsByName(nombre));
        }

        [HttpGet]
        [Route("dinamic/ordenamiento/{nombre}")]
        public IHttpActionResult GetOrdenamiento(string nombre)
        {
            return Ok(services.GetPersonsByNameDireccion(nombre));
        }

        [HttpGet]
        [Route("dinamic/leftjoin")]
        public IHttpActionResult GetOrdenamientoLeftJoin()
        {
            return Ok(services.GetPersonsLeftJoin());
        }

        [HttpGet]
        [Route("dinamic/distinct")]
        public IHttpActionResult GetDistinct()
        {
            return Ok(services.GetPersonsDistinct());
        }




    }
}
