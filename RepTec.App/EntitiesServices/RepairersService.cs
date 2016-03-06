using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class RepairersService
    {
        public void Insert(Repairer repairer)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.RepairersRepository.Insert(repairer);
                db.Commit();
            }
        }

        public List<Repairer> GetAll()
        {
            List<Repairer> repairers;
            using (var db = new RepTecUnitOfWork())
            {
                repairers = db.RepairersRepository.GetAll();
            }
            return repairers;
        }

        public Repairer GetById(int id)
        {
            Repairer repairer;
            using (var db = new RepTecUnitOfWork())
            {
                repairer = db.RepairersRepository.GetByСondition(r => r.Id == id);
            }
            return repairer;
        }

        public void Update(Repairer repairer)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.RepairersRepository.Update(repairer);
                db.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.RepairersRepository.Delete(id);
                db.Commit();
            }
        }
    }
}