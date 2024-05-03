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
    
    internal class InsertDocumentoHandler: IRequestHandler<InsertDocumentoCmnd>
    {
        private readonly IDocumentoRepository repoDoc;

        public InsertDocumentoHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }

        public Task Handle(InsertDocumentoCmnd request, CancellationToken cancellationToken)
        {
            repoDoc.Insert(request.documento);
            return Task.CompletedTask;  
        }
    }
}
