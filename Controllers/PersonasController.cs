using Api.DsiCode.Principal.Data;
using Api.DsiCode.Principal.Infraestructura;
using Api.DsiCode.Principal.Models;
using Api.DsiCode.Principal.Services;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.DsiCode.Principal.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly IPersonaServices services;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public PersonasController()
        {
            services = new PersonaServices();       
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

        [HttpGet]
        [Route("dinamic/objects")]
        public IHttpActionResult GetAllObjects()
        {
            var mapper = WebApiApplication.Mapper;
            var lista = services.GetAllData();
            var personas =lista.Select(p => new PersonasDto
            {
                Nombre = p.Nombre,
                ApellidoPaterno = p.ApellidoPaterno,
                ApellidoMaterno = p.ApellidoMaterno,
                Edad = p.Edad,
                Id = p.Id,
                IdDireccion = p.IdDireccion!=null ? p.IdDireccion.Value :0,
                IdTelefono = p.IdTelefono !=null ? p.IdTelefono.Value : 0,
                
                Direcciones = new DireccionesDto 
                {
                    Id = p.direcciones.Id,
                    Calle = p.direcciones.Calle,
                    NumInterior = p.direcciones.NumInterior,
                    NumExterior = p.direcciones.NumExterior
                },
                Telefonos = new TelefonosDto
                {
                    NumeroCasa = p.telefonos !=null ? p.telefonos.NumeroCasa :"" ,
                    NumeroCelular = p.telefonos !=null ? p.telefonos.NumeroCelular: ""
                }
            }).ToList();

            return Ok(AutoMapper.Mapper.Map<List<PersonasDto>>(personas));
        }



    }
}
