using Api.DsiCode.Principal.Data;
using Api.DsiCode.Principal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Api.DsiCode.Principal.Infraestructura
{
    public class AutomaperProfile : AutoMapper.Profile
    {
        public AutomaperProfile()
        {
            CreateMap<DireccionesDto, direcciones>().ReverseMap();
           CreateMap<PersonasDto,personas>()
                .ForMember(dest=> dest.telefonos, opt => opt.MapFrom(src=> src.Telefonos))
                .ForMember(dest => dest.direcciones, opt=> opt.MapFrom(src => src.Direcciones))
                .ReverseMap();

           
        }
                public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperProfile>();
            });
        }
    }
}