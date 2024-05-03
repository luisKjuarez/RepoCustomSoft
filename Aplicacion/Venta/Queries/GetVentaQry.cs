using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Aplicacion.Venta.Queries
{
        public record GetVentaQry : IRequest<IEnumerable<TdVenta>>;

}
