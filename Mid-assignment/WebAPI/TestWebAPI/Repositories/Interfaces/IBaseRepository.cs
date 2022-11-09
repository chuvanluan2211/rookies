using System.Linq.Expressions;

namespace TestWebAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        T GetById(Expression<Func<T, bool>> predicate);

        T Create(T model);

        T Update(T model);

        bool Delete(T model);

        int SaveChanges();

        IDatabaseTransaction DatabaseTransaction();
    }
}
