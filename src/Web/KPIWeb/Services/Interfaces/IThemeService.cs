namespace KPIWeb.Services.Interfaces
{
    public interface IThemeService
    {
        Task<List<ThemeDto>> GetThemes();
        Task<ThemeDto> GetById(int id);
    }
}