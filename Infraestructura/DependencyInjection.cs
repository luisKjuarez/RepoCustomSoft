using Infraestructura.Repositorios.implementacion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
 
namespace Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructuraService(this IServiceCollection services,string connStr)
        {
                 return services;
        }
    }

}
