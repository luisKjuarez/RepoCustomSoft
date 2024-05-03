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
    internal class InsVentaHandler : IRequestHandler<InsertVentaCmnd>
    {

        private readonly IVentaRepository repoVenta;
        public InsVentaHandler(IVentaRepository repoVenta)
        {
            this.repoVenta = repoVenta;
        }
        public Task Handle(InsertVentaCmnd request, CancellationToken cancellationToken)
        {
            repoVenta.Insert(request.venta);
            return Task.CompletedTask;  
        }
    }
}
