using Api.DsiCode.Principal.Infraestructura;
using AutoMapper;
using NLog;
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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            AutomaperProfile.Run();
            Logger.Info("Aplicación iniciada.");
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            
        }
        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            Logger.Error(exception, "Ocurrió un error en la aplicación.");
        }
    }
}
