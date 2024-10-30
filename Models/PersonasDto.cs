using Api.DsiCode.Principal.Data;
using System;

namespace Api.DsiCode.Principal.Models
{
    public class PersonasDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public int IdDireccion { get; set; }
        public int IdTelefono { get; set; }
        public DireccionesDto Direcciones { get; set; }
        public TelefonosDto Telefonos { get; set; }

    }
}