using Api.DsiCode.Principal.Data;
using System.Collections.Generic;

namespace Api.DsiCode.Principal.Models
{
    public class DireccionesDto
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }

       public List<PersonasDto> Personas { get; set; }
    }
}