using AutoMapper;
using KP.Domain.Entities;

namespace KP.Infrastructure.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseModelDto, BaseEntity>().IncludeAllDerived().IgnoreBaseEntityProperties().ReverseMap();
            CreateMap<MeasureDto, Measure>().ForMember(x => x.Kpis, c => c.Ignore()).ReverseMap();
            CreateMap<DirectionsOfTravelDto, DirectionsOfTravel>().ForMember(x => x.Kpis, c => c.Ignore()).ReverseMap();
            CreateMap<KpiDto, Kpi>().ReverseMap();
            CreateMap<KpiTypeDto, KpiType>().ForMember(x => x.Measures, c => c.Ignore()).ReverseMap();
            CreateMap<MeasureTypeDto, MeasureType>().ReverseMap();
            CreateMap<StatusDto, Status>().ForMember(x => x.Kpis, c => c.Ignore()).ReverseMap();
            CreateMap<ThemeDto, Theme>().ForMember(x => x.Measures, c => c.Ignore()).ReverseMap();
            CreateMap<UnitsOfMeasureDto, UnitsOfMeasure>().ForMember(x => x.Kpis, c => c.Ignore()).ReverseMap();
        }
    }

    internal static class MappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreBaseEntityProperties<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapping)
            where TDestination : BaseEntity
        {
            //mapping.ForMember(e => e.RowVersion, c => c.Ignore());
            mapping.ForMember(e => e.IsDeleted, c => c.Ignore());
            //mapping.ForMember(e => e.Id, c => c.Ignore());
            //mapping.ForMember(e => e.CreatedOn, c => c.Ignore());
            //mapping.ForMember(e => e.ModifiedOn, c => c.Ignore());
            //mapping.ForMember(e => e.CreatedByName, c => c.Ignore());
            //mapping.ForMember(e => e.ModifiedByName, c => c.Ignore());

            return mapping;
        }
    }
}