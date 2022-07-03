using AutoMapper;
using KP.Domain.Entities;
using KP.Infrastructure.Configuration;
using KP.Infrastructure.Dtos;

namespace KP.UnitTests;

public class MappingProfileTests
{
    private readonly IMapper _mapper;
    public MappingProfileTests()
    {
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = mockMapper.CreateMapper();
    }
    [Fact]
    public void Map_Customer_CreateCustomerModel_ShouldHaveValidConfig()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<DirectionsOfTravel, DirectionsOfTravelDto>());

        configuration.AssertConfigurationIsValid();
    }
}