using System;

namespace MSSA.Canvas_Your_Goals.Models.ViewModels
{
    public class PagingInfo
    {
        // fields
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        
        // constructors


        // methods
        public int TotalPages()
            => (int) Math.Ceiling((double) TotalItems / ItemsPerPage);


    } // class ends
} // namespace ends
