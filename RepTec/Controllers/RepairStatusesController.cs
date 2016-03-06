using RepTec.App.EntitiesServices;
using RepTec.Core.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace RepTec.Controllers
{
    public class RepairStatusesController : ApiController
    {
        // GET api/RepairStatuses
        public IEnumerable<RepairStatus> Get()
        {
            var repairStatusesService = new RepairStatusesService();
            var repairStatuses = repairStatusesService.GetAll();

            return repairStatuses;
        }
    }
}