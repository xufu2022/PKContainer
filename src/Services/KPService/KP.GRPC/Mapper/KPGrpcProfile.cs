using AutoMapper;
using KP.GRPC.Protos;
using KP.Infrastructure.Dtos;

namespace KP.Grpc.Mapper;

public class KPGrpcProfile: Profile
{
    public KPGrpcProfile()
    {
        CreateMap<ThemeDto, ThemeReply>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));
        //.ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.CreatedTime)));
    }
}