namespace KPIWeb.Services.Interfaces
{
    public interface IStatusService
    {
        Task<List<StatusDto>> GetStatuses();
        Task<StatusDto> GetById(int id);
    }
}