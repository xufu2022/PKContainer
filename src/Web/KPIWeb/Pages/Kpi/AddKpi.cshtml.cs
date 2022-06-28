using System.ComponentModel.Design;
using KPIWeb.Models;
using KPIWeb.Services.Interfaces;
using KPIWeb.Utitity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPIWeb.Pages.Kpi
{
    public class AddKpiModel : PageModel
    {
        private readonly IKPIApiService _kpiApiService;
        private readonly IMeasureService _measureService;
        private readonly IDirectionsOfTravelService _directionsOfTravelService;
        private readonly ILogger<AddKpiModel> _logger;

        public AddKpiModel(IKPIApiService kpiApiService, IMeasureService measureService, ILogger<AddKpiModel> logger, IDirectionsOfTravelService directionsOfTravelService)
        {
            _kpiApiService = kpiApiService;
            _measureService = measureService;
            _logger = logger;
            _directionsOfTravelService = directionsOfTravelService;
        }
        [FromRoute]
        public int Id { get; set; }
        public string MeasureName { get; set; }
        [BindProperty] public KpiDto KpiDto { get; set; } = new();

        public List<SelectListItem> DirectionsOfTravelList;

        public async Task OnGet()
        {
            var measure = await _measureService.GetById(Id);
            MeasureName = (await _measureService.GetById(Id)).Name;
            var directionOfTravels = await _directionsOfTravelService.GetAllTravelDirections();
            KpiDto.MeasureId = measure.Id;
            DirectionsOfTravelList = new Helper().PopulateDirectionList(directionOfTravels, true);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            KpiDto.CreatedBy = User?.Identity?.Name;
            KpiDto.CreatedOn = DateTime.Now;
            await _kpiApiService.Create(KpiDto);
            return RedirectToPage("/home/index",null,"");


        }

    }
}
