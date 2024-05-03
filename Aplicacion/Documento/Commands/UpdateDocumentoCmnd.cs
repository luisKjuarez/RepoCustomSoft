using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Documento.Commands
{
    
    public record UpdateDocumentoCmnd(TdDocumento documento) : IRequest;

}
