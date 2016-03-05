using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class RepairRequestsRepository : EfGenericRepository<RepairRequest, int>
    {
        public RepairRequestsRepository(DbContext context) : base(context)
        {
        }
    }
}