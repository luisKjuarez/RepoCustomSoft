using Aplicacion.Documento.Commands;
using Aplicacion.Documento.Queries;
using Dominio.Excepciones;
using Aplicacion.Servicios.interfaces;
using Aplicacion.Venta.Commands;
using Aplicacion.Venta.Queries;
using Dominio.Dto;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Modelos;
using System.Diagnostics;
using MimeKit;

namespace TestCustomSoft.Controllers
{
    [ApiController]
    [Route("documento")]
    public class DocumentoController : ControllerBase
    {
        private readonly ILogger<DocumentoController> _logger;
        private readonly ISender sender;
        private readonly IApiKeyValidator validatorKey;
        private readonly  ITransformToDirectory transformDirectory;
        public DocumentoController(ILogger<DocumentoController> logger, ISender sender, IApiKeyValidator validatorKey, ITransformToDirectory transformDirectory)
        {
            _logger = logger;
            this.sender = sender;
            this.validatorKey = validatorKey;   
            this.transformDirectory = transformDirectory;
        }

        [HttpGet("getAllByVenta/{idVenta}")]
 
        public async  Task<List<TdDirectoryDto>> GetByVenta(int idVenta)
        {
            List<TdDocumento> documentos = (List<TdDocumento>)await sender.Send(new GetDocumentoByVentaQry(idVenta));
            return transformDirectory.transformToDto(documentos);
        } 

        [HttpGet("download/{idDocumento}")]
        public async Task<IActionResult>  getFile( int idDocumento)
        {
            TdDocumento documento = (TdDocumento)await sender.Send(new GetDocumentoById(idDocumento));


            var filePath = Path.Combine(documento.Ruta, documento.Nombre);
            if (filePath == null) return NotFound();

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }

        [DisableRequestSizeLimit]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = 1073741824)]
        [HttpPost("upload/{idVenta}")]
        public async Task<IActionResult> UploadFile(int idVenta, [FromForm] IFormFile documento)
        {
            
            string? apiKey = Request.Headers["CSAPIKEY"];
            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();
            
            bool isValid = validatorKey.IsValidApiKey(apiKey);
            if (!isValid)
                return Unauthorized();

            TdDocumentoDto dto = new TdDocumentoDto();
            using (var ms = new MemoryStream())
            {
                documento.CopyTo(ms);
                var fileBytes = ms.ToArray();
                 dto.archivo = fileBytes;
            }
            dto.Nombre = documento.FileName;
            dto.IdVenta= idVenta;
            try
            {
               await sender.Send(new SaveDocumentoCmd(dto));
            }catch(Exception e)
            {
                return StatusCode(500,e.Message); 
            }

            return Ok();
        }



    }
}
