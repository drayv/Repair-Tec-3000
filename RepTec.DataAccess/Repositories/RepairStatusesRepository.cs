using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class RepairStatusesRepository : EfGenericRepository<RepairStatus, int>
    {
        public RepairStatusesRepository(DbContext context) : base(context)
        {
        }
    }
}