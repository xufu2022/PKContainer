using KPIWeb.Models;
using KPIWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KPIWeb.Pages.Home;

public class IndexModel : PageModel
{
    private readonly IThemeService _themeService;
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(IKPIApiService kpiApiService, IMeasureService measureService, IThemeService themeService, ILogger<IndexModel> logger)
    {
        _themeService = themeService;
        _logger = logger;
    }

    public List<ThemeDto> ThemesViewmodel { get; set; }

    public async Task OnGet()
    {
        ThemesViewmodel = await _themeService.GetThemes();
        

    }
}