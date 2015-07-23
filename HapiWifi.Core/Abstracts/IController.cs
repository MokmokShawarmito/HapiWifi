using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Abstracts
{
    public interface IController<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetById(int id);
        Boolean Add(T entity);
        Boolean Update(T entity);
        Boolean Delete(T entity);
    }
}
