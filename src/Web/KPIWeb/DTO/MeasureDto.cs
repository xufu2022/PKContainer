namespace KPIWeb.DTO
{
    public  class MeasureDto:BaseModelDto
    {
        public string Name { get; set; }
        public int? ThemeId { get; set; }
        public int? UnitsOfMeasureId { get; set; }
        public int? KpitypeId { get; set; }
        public bool? Active { get; set; }

        public virtual KpitypeDto Kpitype { get; set; }
        public virtual ThemeDto Theme { get; set; }
    }
}