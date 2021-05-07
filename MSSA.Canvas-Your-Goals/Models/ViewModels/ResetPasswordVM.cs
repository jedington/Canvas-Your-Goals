using System.ComponentModel.DataAnnotations;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class ResetPasswordVM
    {
        [MaxLength(40, ErrorMessage = "Email is limited to 40 total characters")]
        [Required(ErrorMessage = "Email is Required")]
        //- [Compare(nameof(User.Email))]
        public string Email { get; set; }

        [MaxLength(40, ErrorMessage = "Answer is limited to 40 total characters")]
        [Required(ErrorMessage = "Answer is Required")]
        //- [Compare(nameof(User.SecurityAnswer))]
        public string SecurityAnswer { get; set; } 

        
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        [Required(ErrorMessage = "New Password is Required")]

        public string NewPassword { get; set; }

        [CompareAttribute("NewPassword", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage = "Please Confirm your Password")]
        public string ConfirmPassword { get; set; }


    } // class ends
} // namespace ends
