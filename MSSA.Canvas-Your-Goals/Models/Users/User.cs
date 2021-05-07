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
        
        [Required(ErrorMessage = "An Email is Required")]
        public string Email { get; set; } // Email property ends (102)
        
        [Required(ErrorMessage = "A Password is Required")]
        public string Password { get; set; } // Password property ends (102)

        public string SecurityHint { get; set; } // SecurityHint property ends (102)

        public string SecurityAnswer { get; set; } // SecurityAnswer property ends (102)

        public bool? IsAdmin { get; set; }
    } // class ends
} // namespace ends
