using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Venta.Commands
{
     
    public record InsertVentaCmnd(TdVenta venta) : IRequest;

}
