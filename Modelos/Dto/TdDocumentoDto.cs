using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class TdDocumentoDto
    {
        
        public string? Nombre { get; set; }

        public int IdVenta { get; set; }

        public byte[]? archivo {  get; set; }    

     }
}
