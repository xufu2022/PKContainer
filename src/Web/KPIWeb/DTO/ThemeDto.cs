namespace KPIWeb.DTO
{
    public class ThemeDto : BaseModelDto
    {
        public string Name { get; set; }
        public virtual List<MeasureDto> Measures { get; set; }
    }
}