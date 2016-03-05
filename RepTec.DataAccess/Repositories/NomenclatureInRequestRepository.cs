using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class NomenclatureInRequestRepository : EfGenericRepository<NomenclatureInRequest, int>
    {
        public NomenclatureInRequestRepository(DbContext context) : base(context)
        {
        }
    }
}