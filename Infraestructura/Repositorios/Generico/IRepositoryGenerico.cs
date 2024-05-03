using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios.Generico
{
    public interface IRepositoryGenerico<T>
    {

          int Insert(T entity);
        int Delete(int entity);
        int Update(T entity);

        T GetById(long id);
        List<T> GetAll();
    }
}
