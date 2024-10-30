using Api.DsiCode.Principal.Infraestructura;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Api.DsiCode.Principal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IMapper Mapper { get; private set; }
        protected void Application_Start()
        {

            // Configuración de AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomaperProfile>();
            });

            Mapper = config.CreateMapper();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutomaperProfile.Run();
            
        }
    }
}
