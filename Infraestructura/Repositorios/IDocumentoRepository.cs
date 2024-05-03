using Infraestructura.Repositorios.Generico;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Infraestructura.Repositorios
{
    public interface IDocumentoRepository : IRepositoryGenerico<TdDocumento>
    {
        List<TdDocumento> getAllByIdVenta(int idVenta);

    }

}
