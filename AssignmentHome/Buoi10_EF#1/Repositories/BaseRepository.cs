using Buoi10_EF_1.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Buoi10_EF_1.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        private readonly DbSet<T> _dbSet;

        private readonly StudentContext _context;

        public BaseRepository(StudentContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public T Create(T model)
        {
            return _dbSet.Add(model).Entity;
        }

        public bool Delete(T model)
        {
            _dbSet.Remove(model);

            return true;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
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