using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MSSA.Canvas_Your_Goals.Models
{
    [Table("Task")]
    public class Task
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [HiddenInput(DisplayValue = false)]
        //- [ForeignKey(nameof(Goal.GoalId))]
        public int GoalId { get; set; }

        public Goal Goal { get; set; }

        public IEnumerable<Step> Steps { get; set; }


        [MaxLength(30, ErrorMessage = "Task Name is Limited to 30 total characters")]
        [Required(ErrorMessage = "A Name is Required")]
        public string TaskName { get; set; }

        public int? TaskOrder { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "A Start Date is Required")]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(2000, ErrorMessage = "Details is Limited to 2000 characters")]
        public string Details { get; set; }
    } // class ends
} // namespace ends
