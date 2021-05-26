using System.ComponentModel.DataAnnotations;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class ResetPasswordVM
    {
        [MaxLength(40, ErrorMessage = "Email is limited to 40 total characters")]
        [Required(ErrorMessage = "Email is Required")]
        //- [Compare(nameof(User.Email))]
        public string Email { get; set; }
    } // class ends
} // namespace ends
