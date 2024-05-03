using Aplicacion.Documento.Queries;
using Infraestructura.Repositorios;
using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Documento.Handlers
{


    public class GetDocumentoByIdHandler : IRequestHandler<GetDocumentoById, TdDocumento>
    {
        private readonly IDocumentoRepository repoDoc;

        public GetDocumentoByIdHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
        public async Task<TdDocumento> Handle(GetDocumentoById request, CancellationToken cancellationToken)
        {
            TdDocumento documento = repoDoc.GetById(request.id);

            return documento;
        }
    }
}
