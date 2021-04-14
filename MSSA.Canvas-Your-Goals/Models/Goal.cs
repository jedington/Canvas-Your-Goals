using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MSSA.Canvas_Your_Goals.Models
{
    [Table("Goal")]
    public class Goal
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? GoalId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey(nameof(User.UserId))]
        public int? UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey(nameof(VisionBoard.VisionBoardId))]
        public int? VisionBoardId { get; set; }

        [MaxLength(30, ErrorMessage = "Goal Name is Limited to 30 total characters")]
        [Required(ErrorMessage = "A Name is Required")]
        public string GoalName { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        // [Display(Name = "Input what the goal is about")]
        [MaxLength(2000, ErrorMessage = "Details is Limited to 2000 characters")]
        public string Details { get; set; }
    } // class ends
} // namespace ends
