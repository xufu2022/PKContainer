using KPIWeb.DTO;

namespace KPIWeb.Services.Interfaces
{
    public interface IMeasureService
    {
        Task<List<MeasureDto>> GetMeasures();
    }
}