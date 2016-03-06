using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class RepairRequestsController : ApiController
    {
        // GET api/RepairRequests
        public IEnumerable<RepairRequest> Get()
        {
            var repairRequestsService = new RepairRequestsService();
            var repairRequests = repairRequestsService.GetAll();

            return repairRequests;
        }

        // GET api/RepairRequests/5
        public RepairRequest Get(int id)
        {
            var repairRequestsService = new RepairRequestsService();
            return repairRequestsService.GetById(id);
        }

        // POST api/RepairRequests
        public void Post([FromBody]RepairRequest value)
        {
            var repairRequestsService = new RepairRequestsService();
            repairRequestsService.Insert(value);
        }

        // PUT api/RepairRequests/5
        public void Put(int id, [FromBody]RepairRequest value)
        {
            var repairRequestsService = new RepairRequestsService();
            repairRequestsService.Update(value);
        }

        // DELETE api/RepairRequests/5
        public void Delete(int id)
        {
            var repairRequestsService = new RepairRequestsService();
            repairRequestsService.Delete(id);
        }
    }
}