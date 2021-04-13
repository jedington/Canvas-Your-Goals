using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IGoalRepository
    {
        // create
        public Goal CreateGoal(Goal p);


        // read
        public IQueryable<Goal> GetAllGoals();

        public IQueryable<string> GetAllCategories();

        public Goal GetGoalById(int productId);

        public IQueryable<Goal> GetGoalsByKeyword(string keyword);


        // update
        public Goal UpdateGoal(Goal goal);


        // delete
        public bool DeleteGoal(int id);


    } // class ends
} // namespace ends
