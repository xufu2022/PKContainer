namespace KP.Domain.Entities;

public partial class UnitsOfMeasure : BaseEntity
{
    public string Name { get; set; } = "";

    public ICollection<Kpi> Kpis { get; set; } = new HashSet<Kpi>();
    public ICollection<Measure> Measures { get; set; } = new HashSet<Measure>();
}