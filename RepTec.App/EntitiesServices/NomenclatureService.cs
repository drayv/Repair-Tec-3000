using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class NomenclatureService
    {
        public void Insert(Nomenclature nomenclature)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var type = db.NomenclatureTypesRepository.GetByСondition(t => t.Id == nomenclature.Type.Id);
                nomenclature.Type = type;
                db.NomenclatureRepository.Insert(nomenclature);
                db.Commit();
            }
        }

        public List<Nomenclature> GetAll()
        {
            List<Nomenclature> nomenclature;
            using (var db = new RepTecUnitOfWork())
            {
                nomenclature = db.NomenclatureRepository.GetAll(null, n => n.Type);
            }
            return nomenclature;
        }

        public Nomenclature GetById(int id)
        {
            Nomenclature nomenclature;
            using (var db = new RepTecUnitOfWork())
            {
                nomenclature = db.NomenclatureRepository.GetByСondition(r => r.Id == id, n => n.Type);
            }
            return nomenclature;
        }

        public void Update(Nomenclature nomenclature)
        {
            using (var db = new RepTecUnitOfWork())
            {
                var type = db.NomenclatureTypesRepository.GetByСondition(t => t.Id == nomenclature.Type.Id);
                nomenclature.Type = type;
                db.NomenclatureRepository.Update(nomenclature);
                db.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var db = new RepTecUnitOfWork())
            {
                db.NomenclatureRepository.Delete(id);
                db.Commit();
            }
        }
    }
}