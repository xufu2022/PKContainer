namespace KP.Infrastructure.Dtos;

public record class MeasureDto(string Name, int? ThemeId, int? UnitsOfMeasureId, int? KpiTypeId, bool? Active, KpiTypeDto? KpiType, ThemeDto Theme, UnitsOfMeasureDto UnitsOfMeasure) : BaseModelDto { }