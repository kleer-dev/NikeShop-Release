using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your phone number")]
        [MaxLength(13, ErrorMessage = " Exceeded maximum number length(13 characters)")]
        [MinLength(13, ErrorMessage = "Minimum number length - 13 characters")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Phone number must be digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your password number")]
        [MinLength(8, ErrorMessage = "The minimum length of the password is 8 characters")]
        [MaxLength(15, ErrorMessage = "Password length must not exceed 15 characters")]
        public string Password { get; set; }
    }
}
