using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Aplicacion.Documento.Queries
{
    public record GetDocumentoQry (): IRequest<IEnumerable<TdDocumento>>;

   
}
