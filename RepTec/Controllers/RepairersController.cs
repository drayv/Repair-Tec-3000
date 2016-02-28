using Newtonsoft.Json;
using RepTec.App.EntitiesServices;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class RepairersController : ApiController
    {
        // GET api/Repairers
        public IEnumerable<string> Get()
        {
            var repairersService = new RepairersService();
            var repairers = repairersService.GetAll();
            var json = JsonConvert.SerializeObject(repairers);
            
            yield return json;
        }

        // GET api/Repairers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Repairers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Repairers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Repairers/5
        public void Delete(int id)
        {
        }
    }
}