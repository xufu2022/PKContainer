namespace KPIWeb.Models
{
    public class KPIViewModel
    {
        public List<MeasureDto> Measures { get; set; }

        public List<ThemeDto> Themes { get; set; }

        public KpiDto? kpiModel { get; set; }
    }
}
