using Api.DsiCode.Principal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DsiCode.Principal.Infraestructura
{
    public interface IPersonaServices
    {
        List<personas> GetAllByDireccion(int id);
        List<personas> GetPersonas();
    }
}
