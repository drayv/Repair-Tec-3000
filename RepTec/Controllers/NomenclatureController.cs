using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class NomenclatureController : ApiController
    {
        // GET api/Nomenclature
        public IEnumerable<Nomenclature> Get()
        {
            var nomenclatureService = new NomenclatureService();
            var nomenclature = nomenclatureService.GetAll();

            return nomenclature;
        }

        // GET api/Nomenclature/5
        public Nomenclature Get(int id)
        {
            var nomenclatureService = new NomenclatureService();
            return nomenclatureService.GetById(id);
        }

        // POST api/Nomenclature
        public void Post([FromBody]Nomenclature value)
        {
            var nomenclatureService = new NomenclatureService();
            nomenclatureService.Insert(value);
        }

        // PUT api/Nomenclature/5
        public void Put(int id, [FromBody]Nomenclature value)
        {
            var nomenclatureService = new NomenclatureService();
            nomenclatureService.Update(value);
        }

        // DELETE api/Nomenclature/5
        public void Delete(int id)
        {
            var nomenclatureService = new NomenclatureService();
            nomenclatureService.Delete(id);
        }
    }
}