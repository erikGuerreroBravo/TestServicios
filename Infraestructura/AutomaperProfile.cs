using Api.DsiCode.Principal.Data;
using Api.DsiCode.Principal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.DsiCode.Principal.Infraestructura
{
    public class AutomaperProfile : AutoMapper.Profile
    {
        public AutomaperProfile()
        {
            CreateMap<DireccionesDto, direcciones>().ReverseMap();
           CreateMap<PersonasDto,personas>().ReverseMap();  
        }
    }
}