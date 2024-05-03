 using Aplicacion.Venta.Commands;
using Dominio.Excepciones;
using Infraestructura.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Venta.Handlers
{
    internal class UpdVentaHandler : IRequestHandler<UpdateVentaCmd>
    {
        private readonly IVentaRepository repoVenta;
        public UpdVentaHandler(IVentaRepository repoVenta)
        {
            this.repoVenta = repoVenta;
        }
        public Task Handle(UpdateVentaCmd request, CancellationToken cancellationToken)
        {
            try
            {
                repoVenta.Update(request.venta);
            }catch(UpdateException e)
            {
                throw;
            }
            return Task.CompletedTask;  
        }
    }
}
