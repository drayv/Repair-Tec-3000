using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess.Repositories
{
    public class NomenclatureRepository : EfGenericRepository<Nomenclature, int>
    {
        public NomenclatureRepository(DbContext context) : base(context)
        {
        }
    }
}