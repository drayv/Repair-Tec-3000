using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class NomenclatureTypesController : ApiController
    {
        // GET api/Nomenclature
        public IEnumerable<NomenclatureType> Get()
        {
            var nomenclatureTypesService = new NomenclatureTypesService();
            var nomenclatureTypes = nomenclatureTypesService.GetAll();

            return nomenclatureTypes;
        }
    }
}