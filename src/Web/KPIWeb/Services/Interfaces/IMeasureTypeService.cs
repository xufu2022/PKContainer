using KPIWeb.DTO;

namespace KPIWeb.Services.Interfaces
{
    public interface IMeasureTypeService
    {
        Task<List<MeasureTypeDto>> GetMeasureTypes();
        Task<MeasureTypeDto> GetById(int id);
    }
}