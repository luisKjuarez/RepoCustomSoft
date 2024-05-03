using Dominio.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Documento.Commands
{
    public record SaveDocumentoCmd(TdDocumentoDto documento) : IRequest;

    
}
