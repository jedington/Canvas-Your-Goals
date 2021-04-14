using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MSSA.Canvas_Your_Goals.Models;

namespace SportsStore.Models
{
    public class ResetPasswordViewModel
    {
        public User DbUser { get; set; }

        [ForeignKey(nameof(User.Password))]
        public string OldPassword { get; set; }

        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        public string NewPassword { get; set; }

        [CompareAttribute("NewPassword", ErrorMessage = "Passwords do not match.")]
        //- [Required(ErrorMessage = "Please Confirm your Password")]
        public string ConfirmPassword { get; set; } // ConfirmPassword property ends (102)


    } // class ends
} // namespace ends
