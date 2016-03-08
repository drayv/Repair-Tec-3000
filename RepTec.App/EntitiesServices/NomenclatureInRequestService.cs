using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class NomenclatureInRequestService
    {
        public void Insert(NomenclatureInRequest nomenclatureInRequest)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var nomenclature = db.NomenclatureRepository.GetByСondition(t => t.Id == nomenclatureInRequest.Nomenclature.Id);
                nomenclatureInRequest.Nomenclature = nomenclature;

                db.NomenclatureInRequestRepository.Insert(nomenclatureInRequest);
                db.Commit();
            }
        }

        public List<NomenclatureInRequest> GetAllByRequest(int requestId)
        {
            List<NomenclatureInRequest> nomenclatureInRequest;
            using (var db = new RepTecUnitOfWork())
            {
                nomenclatureInRequest = db.NomenclatureInRequestRepository.GetAll(n => n.RepairRequestId == requestId,
                    n => n.Nomenclature, n => n.Nomenclature.Type);
            }
            return nomenclatureInRequest;
        }

        public NomenclatureInRequest GetById(int id)
        {
            NomenclatureInRequest nomenclatureInRequest;
            using (var db = new RepTecUnitOfWork())
            {
                nomenclatureInRequest = db.NomenclatureInRequestRepository.GetByСondition(r => r.Id == id,
                    n => n.Nomenclature, n => n.Nomenclature.Type);
            }
            return nomenclatureInRequest;
        }

        public void Update(NomenclatureInRequest nomenclatureInRequest)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var nomenclature = db.NomenclatureRepository.GetByСondition(t => t.Id == nomenclatureInRequest.Nomenclature.Id);
                nomenclatureInRequest.Nomenclature = nomenclature;

                db.NomenclatureInRequestRepository.Update(nomenclatureInRequest);
                db.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.NomenclatureInRequestRepository.Delete(id);
                db.Commit();
            }
        }
    }
}