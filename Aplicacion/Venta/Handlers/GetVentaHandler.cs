 using Aplicacion.Venta.Queries;
using Infraestructura.Repositorios;
using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Aplicacion.Venta.Handlers
{
    internal class GetVentaHandler : IRequestHandler<GetVentaQry, IEnumerable<TdVenta>>
    {
        private readonly IVentaRepository repoVenta;
        public GetVentaHandler(IVentaRepository repoVenta)
        {
            this.repoVenta = repoVenta;
        }
        public async Task<IEnumerable<TdVenta>> Handle(GetVentaQry request, CancellationToken cancellationToken)
        {
            List<TdVenta> ventas = repoVenta.GetAll();

            return ventas;
        }
    }
}
