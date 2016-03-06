using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class RepairStatusesService
    {
        public List<RepairStatus> GetAll()
        {
            List<RepairStatus> repairStatuses;
            using (var db = new RepTecUnitOfWork())
            {
                repairStatuses = db.RepairStatusesRepository.GetAll();
            }
            return repairStatuses;
        }
    }
}