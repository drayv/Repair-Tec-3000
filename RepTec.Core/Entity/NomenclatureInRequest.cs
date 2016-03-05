namespace RepTec.Core.Entity
{
    public class NomenclatureInRequest : Entity<int>
    {
        public RepairRequest RepairRequest { get; set; }
        public Nomenclature Nomenclature { get; set; }
    }
}