

namespace KP.Infrastructure.Services
{
    public interface IThemeService
    {
        Task<List<ThemeDto>> GetList();
        Task<ThemeDto?> GetById(int id);
    }

    public class ThemeService : IThemeService
    {
        private readonly KpiDbContext _context;
        private readonly IMapper _mapper;

        public ThemeService( IMapper mapper, KpiDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ThemeDto>> GetList()=>await _context.Set<Theme>().ProjectTo<ThemeDto>(_mapper.ConfigurationProvider).ToListAsync();
          

        public async Task<ThemeDto?> GetById(int id)=>await _context.Set<Theme>().ProjectTo<ThemeDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x=>x.Id==id);
        
    }
}