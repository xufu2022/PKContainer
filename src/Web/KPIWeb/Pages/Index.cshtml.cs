using KPIWeb.DTO;
using KPIWeb.Models;
using KPIWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KPIWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IKPIApiService _kpiApiService;
    private readonly IMeasureService _measureService;
    private readonly IThemeService _themeService;
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(IKPIApiService kpiApiService, IMeasureService measureService, IThemeService themeService, ILogger<IndexModel> logger)
    {
        _kpiApiService = kpiApiService;
        _measureService = measureService;
        _themeService = themeService;
        _logger = logger;
    }

    public KPIViewModel KpiViewModel { get; set; }

    public async Task OnGet()
    {
        var theme = await _themeService.GetThemes();
        KpiViewModel = new KPIViewModel
        {
            kpiModel = new KpiDto(),
            Themes = theme,
            //Statuses = await _statusService.GetStatuses(),
            //DirectionsOfTravelList = PopulateSelectList(await _directionsOfTravelService.GetAllTravelDirections(), true)
        };
    
    }
}