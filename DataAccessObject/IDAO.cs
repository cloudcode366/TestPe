using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public interface IDAO<T> where T : class
    {
        Task Add(T t);
        Task Remove(T t);
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task Update(T t);
    }
}
