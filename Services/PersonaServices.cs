using Api.DsiCode.Principal.Data;
using Api.DsiCode.Principal.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Api.DsiCode.Principal.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly TestDbMensajeriaEntities contexto= null;

        public PersonaServices()
        {
             contexto = new TestDbMensajeriaEntities();
        }

        public List<personas> GetPersonas()
        {
           return contexto.personas.ToList();
                      
        }

        public List<personas> GetAllPersonas()
        {
            try
            {
                var lista = from persona  in 
                                contexto.personas 
                            select persona;
               return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo se encarga de regresar una lista de objetos anonimos
        /// </summary>
        /// <param name="param">el valor parametrizado de busqueda</param>
        /// <returns>lista dinamica de objetos anonimos</returns>
        /// <exception cref="ArgumentException">excepcon de argumentos</exception>
        public List<dynamic> GetPersonsByName(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException("El parámetro no puede ser nulo o vacío.", nameof(param));
            }
            try
            {
                var lista = 
                    (from p in contexto.personas
                        where p.Nombre.StartsWith(param)
                        select
                new { Nombre = p.Nombre, ApellidoPaterno = p.ApellidoPaterno, ApellidoMaterno = p.ApellidoMaterno }).ToList();
                return lista.Cast<dynamic>().ToList(); // Convertir a dynamic

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo se encarga de consultar las personas y sus direcciones a traves de un parametro de busqueda
        /// y ordena los resultados por nombre de forma ascendente
        /// </summary>
        /// <param name="param">el nombre como parametro de busqueda</param>
        /// <returns>la consulta generada</returns>
        /// <exception cref="ArgumentException"></exception>
        public List<dynamic> GetPersonsByNameDireccion(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException("El parámetro no puede ser nulo o vacío.", nameof(param));
            }
            try
            {
               var lista =
                    (from p in contexto.personas 
                        join d in contexto.direcciones on p.IdDireccion equals d.Id
                        where p.Nombre.StartsWith(param)
                        orderby p.Nombre ascending
                        select
                        new { 
                             Nombre = p.Nombre, 
                             ApellidoPaterno = p.ApellidoPaterno,
                             ApellidoMaterno = p.ApellidoMaterno,
                             Calle= d.Calle,
                             NumeroInterior = d.NumInterior,
                             NumeroExterior=d.NumExterior
                         }).ToList();
                return lista.Cast<dynamic>().ToList(); 

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo  que se encarga de realizar un lefjoin entre 3 tablas
        /// </summary>
        /// <returns>una lista de consulta a 3 tablas</returns>
        public List<dynamic> GetPersonsLeftJoin()
        {
            try
            {
                var lista = (from p in contexto.personas
                            join d in contexto.direcciones on p.IdDireccion
                            equals d.Id into groupDireccion
                            from d in groupDireccion.DefaultIfEmpty() //permite que la direccion sea null
                            join t in contexto.telefonos on p.IdTelefono equals
                            t.Id into groupTelefono
                            from t in groupTelefono.DefaultIfEmpty() //permite que el telefono sea null
                            orderby p.Nombre ascending
                            select new
                            {
                                p.Nombre,
                                p.ApellidoPaterno,
                                p.ApellidoMaterno,
                                Calle = d != null ? d.Calle : null,
                                NumeroInterior = d != null ? d.NumInterior : null,
                                NumeroExterior = d != null ? d.NumExterior : null,
                                NumeroCelular = t != null ? t.NumeroCelular : null,
                                NumeroCasa = t != null ? t.NumeroCasa : null
                            }).ToList();
                return lista.Cast<dynamic>().ToList();

            }
            catch (Exception ex)
            {
                return null;               
            }
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los registros que son estrictamente diferentes
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetPersonsDistinct()
        {
            try
            {
                var lista = (from p in contexto.personas
                            join d in contexto.direcciones on 
                            p.IdDireccion equals d.Id
                            join t in contexto.telefonos on
                            p.IdTelefono equals t.Id
                            select new {
                                Nombre=p.Nombre,
                                ApellidoPaterno =p.ApellidoPaterno,
                                ApellidoMaterno = p.ApellidoMaterno,
                                Calle=d.Calle,
                                NumeroInterior = d.NumInterior,
                                NumeroExterior = d.NumExterior,
                                Celular= t.NumeroCelular,
                                Casa= t.NumeroCasa
                            }).Distinct().ToList();
                return lista.Cast<dynamic>().ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }


        public List<personas> GetPersonasByDirecciones() {

            return contexto.personas.Include("direcciones").ToList();
        }
        public List<personas> GetAllByDireccion(int id)
        {
            return contexto.personas
                .Include("direcciones")
                .Where(p=> p.IdDireccion == id).ToList();
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los datos de la base de datos, realizando una proyeccion de los datos.
        /// </summary>
        /// <returns>una lista de personas</returns>
        public List<personas> GetAllData() {
            try
            {
                var lista = contexto.personas.Include("direcciones").Include("telefonos").ToList();
                return lista;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return null;
            }
        }

        



    }
}