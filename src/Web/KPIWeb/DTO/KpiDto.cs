using System.ComponentModel.DataAnnotations;

namespace KPIWeb.DTO
{
    public  class KpiDto : BaseModelDto
    {
        public int? MeasureId { get; set; }

        [Display(Name = "Lead")]
        [Required(ErrorMessage = "Lead is required")]
        public string Lead { get; set; }

        public int? UnitsOfMeasureId { get; set; }

        [Display(Name = "Actual Closing Position Start Date")]
        [Required(ErrorMessage = "Actual Closing Position Start Date is required")]
        public DateTime? ActualClosingPositionStartDate { get; set; }

        [Display(Name = "Actual Closing Position Start Value")]
        [Required(ErrorMessage = "Actual Closing Position Start Value is required")]
        public string ActualClosingPositionStartValue { get; set; }

        [Display(Name = "Actual Closing Position End Date")]
        [Required(ErrorMessage = "Actual Closing Position End Date is required")]
        public DateTime? ActualClosingPositionEndDate { get; set; }

        [Display(Name = "Actual Closing Position End Value")]
        [Required(ErrorMessage = "Actual Closing Position End Value is required")]
        public string ActualClosingPositionEndValue { get; set; }

        [Display(Name = "Actual YTD Previous")]
        [Required(ErrorMessage = "Actual YTD Previous is required")]
        public string ActualYtdprevious { get; set; }

        [Display(Name = "Actual YTD Current")]
        [Required(ErrorMessage = "Actual YTD Current is required")]
        public string ActualYtdcurrent { get; set; }

        [Display(Name = "Target Date")]
        [Required(ErrorMessage = "Target Date is required")]
        public DateTime? TargetDate { get; set; }

        [Display(Name = "Target Value")]
        [Required(ErrorMessage = "Target Value is required")]
        public string TargetValue { get; set; }

        [Display(Name = "Forecast Date")]
        [Required(ErrorMessage = "Forecast Date is required")]
        public DateTime? ForecastDate { get; set; }

        [Display(Name = "Forecast Value")]
        [Required(ErrorMessage = "Forecast Value is required")]
        public string ForecastValue { get; set; }

        public int? DirectionsOfTravelId { get; set; }
        public int? LikehoodOfAchievingTargetId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual DirectionsOfTravelDto DirectionsOfTravel { get; set; }
        public virtual LikehoodOfAchievingTargetDto LikehoodOfAchievingTarget { get; set; }
        public virtual MeasureDto Measure { get; set; }
        public virtual StatusDto Status { get; set; }
        public virtual UnitsOfMeasureDto UnitsOfMeasure { get; set; }
    }
}