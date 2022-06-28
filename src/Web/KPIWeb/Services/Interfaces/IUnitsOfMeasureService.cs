namespace KPIWeb.Services.Interfaces
{
    public interface IUnitsOfMeasureService
    {
        Task<List<UnitsOfMeasureDto>> GetUnitsOfMeasure();
        Task<UnitsOfMeasureDto> GetById(int id);
    }
}