using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class InsertException : Exception
    {
        public InsertException() { }

        public InsertException(string message)
            : base(String.Format(message))
        {

        }
    }
}
