namespace KP.Domain.Entities
{
    public partial class Measure : BaseEntity
    {
        public string Name { get; set; } = "";
        public int? ThemeId { get; set; }
        public int? UnitsOfMeasureId { get; set; }
        public int? KpiTypeId { get; set; }
        public bool? Active { get; set; }


        public KpiType? KpiType { get; set; }
        public Theme Theme { get; set; }
        public ICollection<Kpi> Kpis { get; set; } = new HashSet<Kpi>();
        public UnitsOfMeasure UnitsOfMeasure { get; set; }
        public Measure(Theme theme, UnitsOfMeasure unitsOfMeasure)
        {
            Theme = theme;
            UnitsOfMeasure = unitsOfMeasure;
        }

        private Measure():this(null!, null!)
        {
        }
    }
}