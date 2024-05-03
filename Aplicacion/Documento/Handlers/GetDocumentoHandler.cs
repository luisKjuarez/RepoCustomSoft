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
    public class GetDocumentoHandler : IRequestHandler<GetDocumentoQry, IEnumerable<TdDocumento>>
    {
        private readonly IDocumentoRepository repoDoc;

        public GetDocumentoHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
        public async Task<IEnumerable<TdDocumento>> Handle(GetDocumentoQry request, CancellationToken cancellationToken)
        {
            List<TdDocumento> documentos = repoDoc.GetAll();

            return documentos;
        }
    }
}
