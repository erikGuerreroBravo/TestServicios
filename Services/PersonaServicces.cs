using Api.DsiCode.Principal.Data;
using Api.DsiCode.Principal.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.DsiCode.Principal.Services
{
    public class PersonaServicces : IPersonaServices
    {
        private readonly TestDbMensajeriaEntities contexto= null;

        public PersonaServicces()
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

        public List<personas> GetPersonasByDirecciones() {

            return contexto.personas.Include("direcciones").ToList();
        }


        public List<personas> GetAllByDireccion(int id)
        {
            return contexto.personas
                .Include("direcciones")
                .Where(p=> p.IdDireccion == id).ToList();
        }



    }
}