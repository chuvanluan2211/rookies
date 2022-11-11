using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data;
using TestWebAPI.Repositories.Interfaces;
namespace TestWebAPI.Repositories.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        protected readonly BookContext _context;
        public BaseRepository(BookContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T Create(T model)
        {
            return _dbSet.Add(model).Entity;
        }

        public IDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }

        public bool Delete(T model)
        {
            _dbSet.Remove(model);
            return true;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T model)
        {
            return _dbSet.Update(model).Entity;
        }
    }
}
