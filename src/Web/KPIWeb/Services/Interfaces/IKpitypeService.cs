using KPIWeb.DTO;

namespace KPIWeb.Services.Interfaces
{
    public interface IKpitypeService
    {
        Task<List<KpitypeDto>> GetKpiTypes();
        Task<KpitypeDto> GetById(int id);
    }
}