using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class RepairRequestsService
    {
        public void Insert(RepairRequest repairRequest)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var status = db.RepairStatusesRepository.GetByСondition(s => s.Id == repairRequest.Status.Id);
                repairRequest.Status = status;

                var equipmentToBeRepaired = db.NomenclatureRepository.GetByСondition(n => n.Id == repairRequest.EquipmentToBeRepaired.Id);
                repairRequest.EquipmentToBeRepaired = equipmentToBeRepaired;

                var repairer = db.RepairersRepository.GetByСondition(r => r.Id == repairRequest.Repairer.Id);
                repairRequest.Repairer = repairer;

                db.RepairRequestsRepository.Insert(repairRequest);
                db.Commit();
            }
        }

        public List<RepairRequest> GetAll()
        {
            List<RepairRequest> repairRequests;
            using (var db = new RepTecUnitOfWork())
            {
                repairRequests = db.RepairRequestsRepository.GetAll(null, r => r.Repairer, r => r.EquipmentToBeRepaired);
            }
            return repairRequests;
        }

        public RepairRequest GetById(int id)
        {
            RepairRequest repairRequest;
            using (var db = new RepTecUnitOfWork())
            {
                repairRequest = db.RepairRequestsRepository.GetByСondition(r => r.Id == id, r => r.Repairer, r => r.EquipmentToBeRepaired);
            }
            return repairRequest;
        }

        public void Update(RepairRequest repairRequest)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var status = db.RepairStatusesRepository.GetByСondition(s => s.Id == repairRequest.Status.Id);
                repairRequest.Status = status;

                var equipmentToBeRepaired = db.NomenclatureRepository.GetByСondition(n => n.Id == repairRequest.EquipmentToBeRepaired.Id);
                repairRequest.EquipmentToBeRepaired = equipmentToBeRepaired;

                var repairer = db.RepairersRepository.GetByСondition(r => r.Id == repairRequest.Repairer.Id);
                repairRequest.Repairer = repairer;

                db.RepairRequestsRepository.Update(repairRequest);
                db.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.RepairRequestsRepository.Delete(id);
                db.Commit();
            }
        }
    }
}