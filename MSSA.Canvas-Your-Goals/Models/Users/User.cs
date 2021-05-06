﻿using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "An Email is Required")]
        public string Email { get; set; } // Email property ends (102)
        
        public string Password { get; set; } // Password property ends (102)

        [MaxLength(40, ErrorMessage = "Hint is limited to 40 total characters")]
        public string SecurityHint { get; set; } // SecurityHint property ends (102)

        [MaxLength(40, ErrorMessage = "Answer is limited to 40 total characters")]
        public string SecurityAnswer { get; set; } // SecurityAnswer property ends (102)

        public bool? IsAdmin { get; set; }
    } // class ends
} // namespace ends
