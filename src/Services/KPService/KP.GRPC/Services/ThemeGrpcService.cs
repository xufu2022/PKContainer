using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using KP.GRPC.Protos;
using KP.Infrastructure.Dtos;
using KP.Infrastructure.Services;
using ThemeService = KP.GRPC.Protos.ThemeService;

namespace KP.GRPC.Services
{
    public class ThemeGrpcService: ThemeService.ThemeServiceBase
    {
        private readonly IThemeService _service;
        private readonly IMapper _mapper;

        public ThemeGrpcService(IThemeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public override async Task GetAll(Empty request, IServerStreamWriter<ThemeReply> responseStream, ServerCallContext context)
        {
            var list = await _service.GetList();
            if (list.Any())
            {
                foreach (var theme in list)
                {
                    await responseStream.WriteAsync(_mapper.Map<ThemeReply>(theme));
                }
                await Task.CompletedTask;
            }
            
            throw new RpcException(new Status(StatusCode.NotFound, "no record found"));
        }

        public override async Task<ThemeReply> Get(ThemeIdRequest request, ServerCallContext context)
        {
            var theme = await _service.GetById(request.Id);
            if (theme == null)
                throw new RpcException(new Status(StatusCode.NotFound, "no record found"));
            return _mapper.Map<ThemeReply>(theme);
        }
        
    }
}
