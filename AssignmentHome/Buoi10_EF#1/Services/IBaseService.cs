using System.Linq.Expressions;
using Buoi10_EF_1.Models;

namespace Buoi10_EF_1.Services
{
    public interface IBaseService<T , K> where T : class where K : class
    {
        T Create(K student);

        T Update(K student);

        T? Get(Expression<Func<T , bool>> predicate);

        bool Delete(K model);

        IEnumerable<T> GetAll(Expression<Func<T , bool>> predicate);

    }
}