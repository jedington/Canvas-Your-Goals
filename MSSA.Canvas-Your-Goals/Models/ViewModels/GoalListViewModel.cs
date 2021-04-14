using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class GoalListViewModel // Data Transfer Object -- DTO
    {
        //   fields and properties
        public IQueryable<Goal> Goals { get; set; }
        public PagingInfo PagingInfo { get; set; }
 
        //   constructors

        //   methods

    } // class ends
} // namespace ends