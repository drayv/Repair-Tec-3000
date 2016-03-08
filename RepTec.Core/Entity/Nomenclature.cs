namespace RepTec.Core.Entity
{
    public class Nomenclature : Entity<int>
    {
        public string Name { get; set; }

        public NomenclatureType Type { get; set; }

        public double Price { get; set; }
    }
}