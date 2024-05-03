using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class TdDirectoryDto
    {

        public int id { get; set; }

        public string? title { get; set; }
        public string? file { get; set; }

        public List<TdDirectoryDto>? children { get; set; }

    }
}
