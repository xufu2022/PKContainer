namespace KP.Domain.Entities;

public class DirectionsOfTravel : BaseEntity
{
    public string Name { get; set; } = "";

    public ICollection<Kpi> Kpis { get; set; } = new HashSet<Kpi>();
}