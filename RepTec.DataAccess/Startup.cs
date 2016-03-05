using Microsoft.Data.Entity;
using RepTec.Core.Entity;
using System.Collections.Generic;

namespace RepTec.DataAccess
{
    public static class Startup
    {
        // This is a workaround for missing seed data functionality in EF 7.0-rc1
        public static void SeedData()
        {
            using (var uof = new RepTecUnitOfWork())
            {
                var count = uof.NomenclatureTypesRepository.GetCount();
                if (count == 0)
                {
                    var nomenclatureTypes = new List<NomenclatureType>();
                    uof.NomenclatureTypesRepository.Insert(nomenclatureTypes);

                    var repairStatuses = new List<RepairStatus>();
                    uof.RepairStatusesRepository.Insert(repairStatuses);

                    uof.Commit();
                }
            }
        }
    }
}