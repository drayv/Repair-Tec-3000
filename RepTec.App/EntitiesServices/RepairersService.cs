using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class RepairersService
    {
        public List<Repairer> GetAll()
        {
            List<Repairer> repairers;
            using (var db = new RepTecUnitOfWork())
            {
                // test insert
                db.RepairersRepository.Insert(new Repairer { Name = "Test!" });
                db.Commit();

                repairers = db.RepairersRepository.GetAll();
            }
            return repairers;
        }
    }
}
