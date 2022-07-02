namespace KP.Domain.Entities
{
    public class KpiType : BaseEntity
    {
        public string Name { get; set; } = "";

        public ICollection<Measure> Measures { get; set; } = new HashSet<Measure>();
    }
}