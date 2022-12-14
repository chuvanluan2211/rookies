using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories
{
    public class EntityDatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _transaction;

        public EntityDatabaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();

        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
