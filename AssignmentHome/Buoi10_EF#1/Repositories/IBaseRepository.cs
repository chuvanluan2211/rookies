using Buoi10_EF_1.Models;
using System.Linq.Expressions;

namespace Buoi10_EF_1.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        IEnumerable<T> GetAll(Expression<Func<T , bool>> predicate);

        T? Get(Expression<Func<T , bool>> predicate);

        T Create(T model);
        
        T Update(T model);
        
        bool Delete(T model);

        int SaveChanges();
    }
}