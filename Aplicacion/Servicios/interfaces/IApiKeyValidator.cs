using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios.interfaces
{
    public interface IApiKeyValidator
    {
        bool IsValidApiKey(string userApiKey);
    }
}

 