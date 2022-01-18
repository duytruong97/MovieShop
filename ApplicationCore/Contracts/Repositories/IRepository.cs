using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{

    // Every table needs to have common CRUD operations base CRUD operations

    // IRepository will be implemented bt Repository
    // T is a placeholer for chile repos that will be replaced by entity of that class

    // MovieRepo => Movie for T
    // UserRepo => User for T
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task< IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> filter);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
