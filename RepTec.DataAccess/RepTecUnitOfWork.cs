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

        public NomenclatureInRequestRepository NomenclatureInRequestRepository
        {
            get { return new NomenclatureInRequestRepository(_dbContext); }
        }

        public NomenclatureRepository NomenclatureRepository
        {
            get { return new NomenclatureRepository(_dbContext); }
        }

        public NomenclatureTypesRepository NomenclatureTypesRepository
        {
            get { return new NomenclatureTypesRepository(_dbContext); }
        }

        public RepairersRepository RepairersRepository
        {
            get { return new RepairersRepository(_dbContext); }
        }

        public RepairRequestsRepository RepairRequestsRepository
        {
            get { return new RepairRequestsRepository(_dbContext); }
        }

        public RepairStatusesRepository RepairStatusesRepository
        {
            get { return new RepairStatusesRepository(_dbContext); }
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