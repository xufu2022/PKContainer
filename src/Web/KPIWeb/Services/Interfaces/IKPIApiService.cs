namespace KPIWeb.Services.Interfaces
{
    public interface IKPIApiService
    {
        Task<List<KpiDto>> GetList();
        Task<KpiDto> GetById(int id);
        Task<KpiDto> Update(int id, KpiDto item);
        Task<KpiDto> Create(KpiDto item);

    }
}
