namespace KP.Domain.Entities
{
    public partial class Status : BaseEntity
    {
        public string Name { get; set; } = "";


        public ICollection<Kpi> Kpis { get; set; } = new HashSet<Kpi>();
    }
}