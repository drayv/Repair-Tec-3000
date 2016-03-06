using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class RepairersController : ApiController
    {
        // GET api/Repairers
        public IEnumerable<Repairer> Get()
        {
            var repairersService = new RepairersService();
            var repairers = repairersService.GetAll();

            return repairers;
        }

        // GET api/Repairers/5
        public Repairer Get(int id)
        {
            var repairersService = new RepairersService();
            return repairersService.GetById(id);
        }

        // POST api/Repairers
        public void Post([FromBody]Repairer value)
        {
            var repairersService = new RepairersService();
            repairersService.Insert(value);
        }

        // PUT api/Repairers/5
        public void Put(int id, [FromBody]Repairer value)
        {
            var repairersService = new RepairersService();
            repairersService.Update(value);
        }

        // DELETE api/Repairers/5
        public void Delete(int id)
        {
            var repairersService = new RepairersService();
            repairersService.Delete(id);
        }
    }
}