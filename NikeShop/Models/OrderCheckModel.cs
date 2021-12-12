using System.ComponentModel.DataAnnotations;

namespace NikeShop.Models
{
    public class OrderCheckModel
    {
        [MaxLength(2, ErrorMessage = "Maximum foot size length - 2 symbols")]
        [Required(ErrorMessage = "The field must be filled")]
        [Range(36, 45, ErrorMessage = "Foot size should be within 36-45 sizes")]
        public string LegSize { get; set; }
    }
}