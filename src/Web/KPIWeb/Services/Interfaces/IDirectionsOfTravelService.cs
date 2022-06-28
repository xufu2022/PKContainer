using KPIWeb.DTO;

namespace KPIWeb.Services.Interfaces
{
    public interface IDirectionsOfTravelService
    {
        Task<List<DirectionsOfTravelDto>> GetAllTravelDirections();
        Task<DirectionsOfTravelDto> GetById(int id);
    }
}