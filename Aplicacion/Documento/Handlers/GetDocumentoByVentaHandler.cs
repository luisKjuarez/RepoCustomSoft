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
    internal class GetDocumentoByVentaHandler : IRequestHandler<GetDocumentoByVentaQry, IEnumerable<TdDocumento>>
    {

        private readonly IDocumentoRepository repoDoc;

        public GetDocumentoByVentaHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
        
        public async Task<IEnumerable<TdDocumento>> Handle(GetDocumentoByVentaQry request, CancellationToken cancellationToken)
        {
            List<TdDocumento> documentos = repoDoc.getAllByIdVenta(request.idVenta);

            return documentos;
        }
    }
}
