using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class Goal
    {
        // fields & properties
        
        // [HiddenInput(DisplayValue = false)]
        // [Key, DatabaseGenerated()]
        public int? GoalId { get; set; } // goalId property ends (102)

        // [HiddenInput(DisplayValue = false)]
        public int? UserId { get; set; } // userId property ends (102)

        [MaxLength(30, ErrorMessage = "Name is limited to 30 total characters")]
        [Required(ErrorMessage = "A Name is Required")]
        public string Goalname { get; set; } // Goalname property ends (102)

        public string Priority { get; set; } // Priority property ends (102)

        public string Status { get; set; } // Status property ends (102)

        public string Type { get; set; } // Type property ends (102)

        public DateTime? Startdate { get; set; } // Startdate property ends (102)
        
        public DateTime? Enddate { get; set; } // Enddate property ends (102)

        // [Display(Name = "Input what the goal is about")]
        [MaxLength(2000, ErrorMessage = "This section is limited to 2000 characters")]
        public string Details { get; set; } // Goalname property ends (102)

        // constructors

        // methods
    }
}
