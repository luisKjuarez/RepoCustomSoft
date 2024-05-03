using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class UpdateException : Exception
    {
        public UpdateException() { }

        public UpdateException(string message)
            : base(String.Format(message))
        {

        }
    }
}
