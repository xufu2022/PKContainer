using KPIWeb.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPIWeb.Models
{
    public class KPIViewModel
    {
        public List<StatusDto> Statuses { get; set; }

        public List<ThemeDto> Themes { get; set; }

        public KpiDto kpiModel { get; set; }

        public List<SelectListItem> DirectionsOfTravelList { get; set; }
    }
}
