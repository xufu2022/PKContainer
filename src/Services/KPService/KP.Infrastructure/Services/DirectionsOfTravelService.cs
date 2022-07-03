

namespace KP.Infrastructure.Services
{
    public interface IDirectionsOfTravelService
    {
        Task<List<DirectionsOfTravelDto>> GetList();
        Task<DirectionsOfTravelDto> GetById(int id);
    }

    public class DirectionsOfTravelService : IDirectionsOfTravelService
    {
        private readonly KpiDbContext _context;
        private readonly IMapper _mapper;

        public DirectionsOfTravelService(IMapper mapper, KpiDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<DirectionsOfTravelDto>> GetList()
        {
            var response = await _context.Set<DirectionsOfTravel>().ToListAsync();
            var result = response.Select(x => _mapper.Map<DirectionsOfTravelDto>(x)).ToList();
            return result;
        }

        public async Task<DirectionsOfTravelDto> GetById(int id)
        {
            var response = await _context.Set<DirectionsOfTravel>().FindAsync(id);
            var result = _mapper.Map<DirectionsOfTravelDto>(response);
            return result;
        }
    }
}