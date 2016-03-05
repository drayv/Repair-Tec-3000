using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class NomenclatureTypesRepository : EfGenericRepository<NomenclatureType, int>
    {
        public NomenclatureTypesRepository(DbContext context) : base(context)
        {
        }
    }
}