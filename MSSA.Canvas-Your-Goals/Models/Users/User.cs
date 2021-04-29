using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MSSA.Canvas_Your_Goals.Models
{
    [Table("User")]
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // UserId property ends (102)
        
        [MaxLength(40, ErrorMessage = "Email is limited to 40 total characters")]
        [EmailAddress, Required(ErrorMessage = "An Email is Required")]
        public string Email { get; set; } // Email property ends (102)
        
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters")]
        [MaxLength(40, ErrorMessage = "Password is limited to 40 total characters")]
        //- [Required(ErrorMessage = "A Password is Required")]
        public string Password { get; set; } // Password property ends (102)

        [MaxLength(40, ErrorMessage = "Hint is limited to 40 total characters")]
        //- [Required(ErrorMessage = "Security Hint is Required")]
        public string SecurityHint { get; set; } // SecurityHint property ends (102)

        [MaxLength(40, ErrorMessage = "Answer is limited to 40 total characters")]
        //- [Required(ErrorMessage = "Security Answer is Required")]
        public string SecurityAnswer { get; set; } // SecurityAnswer property ends (102)
    } // class ends
} // namespace ends
