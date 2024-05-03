using Aplicacion.Servicios.interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios.impl
{
    public class ApiKeyValidator : IApiKeyValidator
    { 
        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
                return false;
            string apiKey = "123456789ABC"; 
            if (apiKey == null || apiKey != userApiKey)
                return false;
            return true;
        }
    }
}


