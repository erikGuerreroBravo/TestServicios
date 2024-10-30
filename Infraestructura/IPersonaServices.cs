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
        List<personas> GetAllData();
        List<personas> GetPersonas();
        List<dynamic> GetPersonsByName(string param);
        List<dynamic> GetPersonsByNameDireccion(string param);
        List<dynamic> GetPersonsDistinct();
        List<dynamic> GetPersonsLeftJoin();
    }
}
