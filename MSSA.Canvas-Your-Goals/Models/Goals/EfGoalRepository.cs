using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfGoalRepository : IGoalRepository
    {
        // fields
        private AppDbContext _context;


        // constructors
        public EfGoalRepository(AppDbContext context)
            => _context = context;
        // EfGoalRepository const ends


        // methods
        //// create
        public Goal CreateGoal(int userId, Goal goal)
        {
            goal.UserId = userId; 
            _context.Goals.Add(goal);
            _context.SaveChanges();
            return goal;
        } // CreateGoal method ends


        //// read
        public IQueryable<Goal> GetAllGoals()
            => _context.Goals; // F-Magic
        // GetAllGoals method ends

        public IQueryable<Goal> GetAllGoals(int userId)
            => _context.Goals.Where(g => g.UserId == userId);
        // GetAllGoals method ends

        public IQueryable<string> GetAllCategories()
            => _context.Goals.Select(p => p.Type)
                                .Distinct();
        // GetAllCategories method ends

        public Goal GetGoalById(int goalId)
            //- Goal goal = _context.Goals
            //-     .Where(goal => goal.GoalId == goalId).FirstOrDefault();
            => _context.Goals.Find(goalId);
         // GetGoalById method ends

        public IQueryable<Goal> GetGoalsByKeyword(string keyword)
            //- IQueryable<Goal> goals = _context.Goals
            //-     .Where(goal => goal.Name.Contains(keyword));
            => _context.Goals.Where(goal => goal.GoalName.Contains(keyword));
        // GetGoalsByKeyword method ends

        //// update
        public Goal UpdateGoal(Goal goal)
        {
            Goal goalToUpdate = _context.Goals.Find(goal.GoalId);
            if (goalToUpdate != null)
            {
                goalToUpdate.GoalName = goal.GoalName;
                goalToUpdate.Priority = goal.Priority;
                goalToUpdate.Status = goal.Status;
                goalToUpdate.Type = goal.Type;
                goalToUpdate.StartDate = goal.StartDate;
                goalToUpdate.EndDate = goal.EndDate;
                _context.SaveChanges();
            }
            return goalToUpdate;
        } // UpdateGoal method ends


        //// delete
        public bool DeleteGoal(int goalId)
        {
            // Goal goalToDelete = _context.Goals.Find(goalId);
            Goal goalToDelete = GetGoalById(goalId);
            if (goalToDelete == null)
            {
                return false;
            }
            _context.Goals.Remove(goalToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteGoal method ends

    } // class ends
} // namespace ends