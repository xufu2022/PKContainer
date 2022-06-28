using System.ComponentModel.DataAnnotations;

namespace KPIWeb.DTO
{
    public class LikehoodOfAchievingTargetDto: BaseModelDto
    {
        [Display(Name = "Likehood Of Achieving Target")]
        [Required(ErrorMessage = "Likehood Of Achieving Target is required")]      
        public string Name { get; set; }
    }
}
