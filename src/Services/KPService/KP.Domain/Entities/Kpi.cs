namespace KP.Domain.Entities;

public partial class Kpi : BaseEntity
{

    public int? MeasureId { get; set; }
    public string? Lead { get; set; }
    public int? UnitsOfMeasureId { get; set; }
    public DateTime? ActualClosingPositionStartDate { get; set; }
    public string? ActualClosingPositionStartValue { get; set; }
    public DateTime? ActualClosingPositionEndDate { get; set; }
    public string? ActualClosingPositionEndValue { get; set; }
    public string? ActualYtdPrevious { get; set; }
    public string? ActualYtdCurrent { get; set; }
    public DateTime? TargetDate { get; set; }
    public string? TargetValue { get; set; }
    public DateTime? ForecastDate { get; set; }
    public string? ForecastValue { get; set; }
    public int? DirectionsOfTravelId { get; set; }
    public int? StatusId { get; set; }

    public DirectionsOfTravel DirectionsOfTravel { get; set; }
    public Measure Measure { get; set; }
    public Status Status { get; set; }
    public UnitsOfMeasure UnitsOfMeasure { get; set; }

    public Kpi(DirectionsOfTravel directionsOfTravel, Measure measure, Status status, UnitsOfMeasure unitsOfMeasure)
    {
        DirectionsOfTravel = directionsOfTravel;
        Measure=measure;
        Status=status;
        UnitsOfMeasure = unitsOfMeasure;
    }

    private Kpi() : this(null!, null!, null!, null!){}
}