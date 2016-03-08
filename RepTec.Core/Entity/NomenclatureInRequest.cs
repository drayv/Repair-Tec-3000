namespace RepTec.Core.Entity
{
    public class NomenclatureInRequest : Entity<int>
    {
        public int RepairRequestId { get; set; }
        public Nomenclature Nomenclature { get; set; }
    }
}