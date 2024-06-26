﻿using Aplicacion.Documento.Handlers;
 using Aplicacion.Venta.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {
            //  services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //  services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
 
            services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                 cfg.RegisterServicesFromAssemblies(typeof(GetVentaHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(GetDocumentoHandler).Assembly);


            });
             
            return services;
        }
    }
}
