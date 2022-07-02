namespace KP.Domain.Entities
{
    public partial class UnitsOfMeasure : BaseEntity
    {
        public string Name { get; set; } = "";

        public virtual ICollection<Kpi> Kpis { get; set; } = new HashSet<Kpi>();
    }
}