using Aplicacion.Documento.Commands;
using Infraestructura.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Documento.Handlers
{
    internal class UpdDocumentoHandler : IRequestHandler<UpdateDocumentoCmnd>
    {
        private readonly IDocumentoRepository repoDoc;

        public UpdDocumentoHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
        public Task Handle(UpdateDocumentoCmnd request, CancellationToken cancellationToken)
        {
            repoDoc.Update(request.documento);
            return Task.CompletedTask;
        }
    }
}
