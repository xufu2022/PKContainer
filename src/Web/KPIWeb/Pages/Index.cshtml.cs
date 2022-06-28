using KPIWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KPIWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public KPIViewModel KpiViewModel { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}