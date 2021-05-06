using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MSSA.Canvas_Your_Goals.Models
{
    [Table("Step")]
    public class Step
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepId { get; set; }

        [HiddenInput(DisplayValue = false)]
        //- [ForeignKey(nameof(Task.TaskId))]
        public int TaskId { get; set; }

        public Task Task { get; set; }

        [MaxLength(30, ErrorMessage = "Step Name is Limited to 30 total characters")]
        [Required(ErrorMessage = "A Name is Required")]
        public string StepName { get; set; }

        public int? StepOrder { get; set; }

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
