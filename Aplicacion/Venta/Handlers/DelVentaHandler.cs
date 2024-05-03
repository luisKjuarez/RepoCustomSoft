 using Aplicacion.Venta.Commands;
using Infraestructura.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Venta.Handlers
{
    internal class DelVentaHandler : IRequestHandler<DeleteVentaCmnd>
    {
        private readonly IVentaRepository repoVenta;
        public DelVentaHandler(IVentaRepository repoVenta)
        {
            this.repoVenta = repoVenta;
        }
        public Task Handle(DeleteVentaCmnd request, CancellationToken cancellationToken)
        {
            repoVenta.Delete(request.venta);
            return Task.CompletedTask;  
        }
    }
}
