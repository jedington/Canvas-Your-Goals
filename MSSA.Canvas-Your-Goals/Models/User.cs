using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class User
    {
        [MaxLength(40, ErrorMessage = "Email is limited to 40 total characters")]
        [EmailAddress, Required(ErrorMessage = "An Email is Required")]
        public string Email { get; set; } // Email property ends (102)
        
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        //- [Required(ErrorMessage = "A Password is Required")]
        public string Password { get; set; } // Password property ends (102)

        [CompareAttribute("Password", ErrorMessage = "Passwords do not match.")]
        //- [Required(ErrorMessage = "Please Confirm your Password")]
        public string ConfirmPassword { get; set; } // ConfirmPassword property ends (102)

        [MaxLength(40, ErrorMessage = "Hint is limited to 40 total characters")]
        //- [Required(ErrorMessage = "Security Hint is Required")]
        public string  SecHint { get; set; } // SecHint property ends (102)

        [MaxLength(40, ErrorMessage = "Answer is limited to 40 total characters")]
        //- [Required(ErrorMessage = "Security Answer is Required")]
        public string  SecAnswer { get; set; } // SecAnswer property ends (102)


        // constructors
        

        // methods


    } // class ends
} // namespace ends
