using System;
using Microsoft.Data.Entity;
using RepTec.DataAccess.Repositories;

namespace RepTec.DataAccess
{
    public class RepTecUnitOfWork : IDisposable
    {
        private DbContext _dbContext;

        public RepTecUnitOfWork()
        {
            _dbContext = new RepTecContext();
            _dbContext.Database.EnsureCreated();
        }

        public RepairersRepository RepairersRepository
        {
            get { return new RepairersRepository(_dbContext); }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext == null) return;
            try
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            catch { }
        }
    }
}