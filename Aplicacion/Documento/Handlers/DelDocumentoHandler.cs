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
    internal class DelDocumentoHandler : IRequestHandler<DeleteDocumentoCmnd>
    {
        private readonly IDocumentoRepository repoDoc;

        public DelDocumentoHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
        public Task Handle(DeleteDocumentoCmnd request, CancellationToken cancellationToken)
        {
            repoDoc.Delete(request.documento );
            return Task.CompletedTask;
        }
    }
}
