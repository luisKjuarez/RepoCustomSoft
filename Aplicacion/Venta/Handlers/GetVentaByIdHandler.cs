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
    public class GetVentaByIdHandler : IRequestHandler<GetVentaByID,TdVenta>
    {
        private readonly IVentaRepository repoVenta;
        public GetVentaByIdHandler(IVentaRepository repoVenta)
        {
            this.repoVenta = repoVenta;
        }

        public async Task<TdVenta> Handle(GetVentaByID request, CancellationToken cancellationToken)
        {
            TdVenta venta = repoVenta.GetById(request.id);

            return venta;
        }

         
    }
}
