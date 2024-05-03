using Aplicacion.Documento.Commands;
 using Dominio.Dto;
using Dominio.Excepciones;
using Infraestructura.Repositorios;
using MediatR;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion.Documento.Handlers
{
    public class SaveDocumentoHandler : IRequestHandler<SaveDocumentoCmd>
    {
        private readonly IDocumentoRepository repoDoc;

        public SaveDocumentoHandler(IDocumentoRepository repoDoc)
        {
            this.repoDoc = repoDoc;
        }
 

        Task IRequestHandler<SaveDocumentoCmd>.Handle(SaveDocumentoCmd request, CancellationToken cancellationToken)
        {
            string uploads = Path.Combine("C:\\Users\\kito_\\Downloads", "uploads");
            TdDocumento docum = new TdDocumento();
            docum.Ruta = uploads;
            docum.IdVenta = request.documento.IdVenta;
            docum.Nombre = request.documento.Nombre;
            try
            {
                if (repoDoc.Insert(docum) == 1)
                {

                    using var writer = new BinaryWriter(File.OpenWrite(Path.Combine(uploads, request.documento.Nombre)));
                    writer.Write(request.documento.archivo);
                }
                else throw new InsertException("Error insertando informacion en la BD");
            }catch(InsertException e)
            {
                throw;
            }
            return Task.CompletedTask;
        }
    } 
}
