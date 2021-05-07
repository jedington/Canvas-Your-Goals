using System.ComponentModel.DataAnnotations;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class ChangePasswordVM
    {
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        [Required(ErrorMessage = "A Password is Required")]
        public string CurrentPassword { get; set; }

        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        [Required(ErrorMessage = "A New Password is Required")]
        public string NewPassword { get; set; }

        [CompareAttribute("NewPassword", ErrorMessage = "Must match with New Password.")]
        [Required(ErrorMessage = "A Confirmation Password is Required")]
        public string ConfirmPassword { get; set; }
    }
}
