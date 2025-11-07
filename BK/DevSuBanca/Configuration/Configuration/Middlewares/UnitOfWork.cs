using Contexto;
using Microsoft.EntityFrameworkCore.Storage;

namespace Configuracion
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
    }

    public class UnitOfWork(BancaContexto context) : IUnitOfWork
    {
        private readonly BancaContexto _dbContext = context;
        private IDbContextTransaction? _transaction;

        public void BeginTransaction()
        {
            if (_transaction is null)
                _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        => _transaction?.Commit();

        public void Rollback()
        => _transaction?.Rollback();

        public void SaveChanges()
        => _dbContext.SaveChanges();
    }
}
