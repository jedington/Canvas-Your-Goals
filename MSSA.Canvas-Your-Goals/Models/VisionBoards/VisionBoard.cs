using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MSSA.Canvas_Your_Goals.Models
{
    [Table("VisionBoard")]
    public class VisionBoard
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisionBoardId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey(nameof(User.UserId))]
        public string UserId { get; set; }

        [MaxLength(30, ErrorMessage = "Vision Name is Limited to 30 total characters")]
        public string VisionName { get; set; }
    } // class ends
} // namespace ends