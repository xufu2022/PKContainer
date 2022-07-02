namespace KP.Domain.Entities
{
    public partial class Theme : BaseEntity
    {
        public string Name { get; set; } = "";


        public virtual ICollection<Measure> Measures { get; set; } = new HashSet<Measure>();
    }
}