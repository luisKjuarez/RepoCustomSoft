using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Documento.Commands
{
     
    public record DeleteDocumentoCmnd(int documento) : IRequest;

}
