using System.ComponentModel.DataAnnotations;

namespace TallerIDWM.Src.DTOs.User
{
    public class ToggleStatusDto
    {
        [StringLength(255)]
        public string? Reason { get; set; }
    }
}
