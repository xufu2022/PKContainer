using KPIWeb.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPIWeb.Models
{
    public class KPIViewModel
    {
        public KpiDto KpiDto { get; set; } = new();

        public List<SelectListItem> DirectionsOfTravelList { get; set; }=new ();

    }

    
}
