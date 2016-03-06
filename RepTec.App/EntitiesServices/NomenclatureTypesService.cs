using RepTec.Core.Entity;
using RepTec.DataAccess;
using System.Collections.Generic;

namespace RepTec.App.EntitiesServices
{
    public class NomenclatureTypesService
    {
        public List<NomenclatureType> GetAll()
        {
            List<NomenclatureType> nomenclatureTypes;
            using (var db = new RepTecUnitOfWork())
            {
                nomenclatureTypes = db.NomenclatureTypesRepository.GetAll();
            }
            return nomenclatureTypes;
        }
    }
}