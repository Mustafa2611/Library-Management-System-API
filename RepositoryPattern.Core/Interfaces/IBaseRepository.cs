using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(int id);

        T CreateNewObject(T entity);
        
        IEnumerable<T> GetAll();

        T FindOne(Expression<Func<T, bool>> match, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
    }
}
