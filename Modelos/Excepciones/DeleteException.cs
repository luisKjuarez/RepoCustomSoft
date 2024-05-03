using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class DeleteException : Exception
    {
        public DeleteException() { }

        public DeleteException(string message)
            : base(String.Format(message))
        {

        }
    }
}
