namespace KP.Infrastructure.Dtos;

public record class KpiDto(int? MeasureId, string? Lead, int? UnitsOfMeasureId, DateTime? ActualClosingPositionStartDate, string? ActualClosingPositionStartValue, DateTime? ActualClosingPositionEndDate, string? ActualClosingPositionEndValue, string? ActualYtdPrevious, string? ActualYtdCurrent, DateTime? TargetDate, string? TargetValue, DateTime? ForecastDate, string? ForecastValue, int? DirectionsOfTravelId, int? StatusId, DirectionsOfTravelDto DirectionsOfTravel, MeasureDto Measure, StatusDto Status, UnitsOfMeasureDto UnitsOfMeasure) : BaseModelDto
{
}