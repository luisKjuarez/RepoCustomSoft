using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplDominioicacion.Excepciones
{
    public class SelectException : Exception
    {
        public SelectException() { }

        public SelectException(string message)
            : base(String.Format(message))
        {

        }
    }
}
