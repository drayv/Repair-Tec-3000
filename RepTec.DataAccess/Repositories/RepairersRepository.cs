using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class RepairersRepository : EfGenericRepository<Repairer, int>
    {
        public RepairersRepository(DbContext context) : base(context)
        {
        }
    }
}