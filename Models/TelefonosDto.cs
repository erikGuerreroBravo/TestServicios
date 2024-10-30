using Api.DsiCode.Principal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.DsiCode.Principal.Models
{
    public class TelefonosDto
    {
        public int Id { get; set; }
        public string NumeroCelular { get; set; }
        public string NumeroCasa { get; set; }

        public List<personas> Personas { get; set; }
    }
}