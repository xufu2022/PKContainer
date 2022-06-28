using KPIWeb.DTO;

namespace KPIWeb.Services.Interfaces
{
    public interface IMeasureService
    {
        Task<List<MeasureDto>> GetMeasures();
        Task<MeasureDto> GetById(int id);
    }
}