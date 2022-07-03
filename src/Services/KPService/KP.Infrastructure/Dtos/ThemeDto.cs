namespace KP.Infrastructure.Dtos;

public record class ThemeDto(string Name, List<MeasureDto> Measures) : BaseModelDto { }