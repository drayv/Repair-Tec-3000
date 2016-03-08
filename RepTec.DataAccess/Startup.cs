using RepTec.Core.Entity;
using System;
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
                    var nomenclatureTypes = new List<NomenclatureType>
                    {
                        new NomenclatureType { Name = "Оборудование" },
                        new NomenclatureType { Name = "Запчасти" },
                        new NomenclatureType { Name = "Услуги" }
                    };
                    uof.NomenclatureTypesRepository.Insert(nomenclatureTypes);

                    var repairStatuses = new List<RepairStatus>
                    {
                        new RepairStatus { Name = "Новая" },
                        new RepairStatus { Name = "В работе" },
                        new RepairStatus { Name = "Выполнена" }
                    };
                    uof.RepairStatusesRepository.Insert(repairStatuses);

                    uof.Commit();

                    var repairers = new List<Repairer>
                    {
                        new Repairer { Name = "Тестовый Абрахим Иванович" },
                        new Repairer { Name = "Тестовый Равшан Владимирович" }
                    };
                    uof.RepairersRepository.Insert(repairers);

                    var obrType = uof.NomenclatureTypesRepository.GetByСondition(n => n.Name == "Оборудование");
                    var zapType = uof.NomenclatureTypesRepository.GetByСondition(n => n.Name == "Запчасти");
                    var uslType = uof.NomenclatureTypesRepository.GetByСondition(n => n.Name == "Услуги");
                    var nomenclature = new List<Nomenclature>
                    {
                        new Nomenclature { Name = "Тестовое оборудование №1", Type = obrType, Price = 987.65 },
                        new Nomenclature { Name = "Тестовая запчасть №1", Type = zapType, Price = 123.45 },
                        new Nomenclature { Name = "Тестовая услуга №1", Type = uslType, Price = 567.89 }
                    };
                    uof.NomenclatureRepository.Insert(nomenclature);

                    uof.Commit();

                    var obr = uof.NomenclatureRepository.GetByСondition(n => n.Name == "Тестовое оборудование №1");
                    var rep = uof.RepairersRepository.GetByСondition(n => n.Name == "Тестовый Равшан Владимирович");
                    var sta = uof.RepairStatusesRepository.GetByСondition(n => n.Name == "Новая");
                    var repairRequest = new List<RepairRequest>
                    {
                        new RepairRequest {
                            Date = DateTime.Now,
                            Address = "г. Киев, ул. Красноармейская 132, п.2",
                            Repairer = rep,
                            EquipmentToBeRepaired = obr,
                            Status = sta,
                            Name = "Это тестовый комментарий к тестовой заявке, можно удалять."
                        }
                    };
                    uof.RepairRequestsRepository.Insert(repairRequest);

                    uof.Commit();
                }
            }
        }
    }
}