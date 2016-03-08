using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class NomenclatureInRequestController : ApiController
    {
        // GET api/NomenclatureInRequest/5
        public IEnumerable<NomenclatureInRequest> Get(int id)
        {
            var nomenclatureService = new NomenclatureInRequestService();
            return nomenclatureService.GetAllByRequest(id);
        }

        // POST api/NomenclatureInRequest
        public void Post([FromBody]NomenclatureInRequest value)
        {
            var nomenclatureService = new NomenclatureInRequestService();
            nomenclatureService.Insert(value);
        }

        // DELETE api/NomenclatureInRequest/5
        public void Delete(int id)
        {
            var nomenclatureService = new NomenclatureInRequestService();
            nomenclatureService.Delete(id);
        }
    }
}