using System;

namespace RepTec.Core.Entity
{
    public class RepairRequest : Entity<int>
    {
        public string Name { get; set; }

        public RepairStatus Status { get; set; }

        public DateTime Date { get; set; }

        public Nomenclature EquipmentToBeRepaired { get; set; }

        public string Adress { get; set; }

        public Repairer Repairer { get; set; }
    }
}