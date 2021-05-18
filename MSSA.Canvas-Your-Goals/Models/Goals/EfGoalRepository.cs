using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfGoalRepository : IGoalRepository
    {
        // fields
        private AppDbContext _context;
        private IUserRepository _userRepository;


        // constructors
        public EfGoalRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        } // EfGoalRepository const ends


        // methods
        //// create
        public Goal CreateGoal(Goal goal)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                goal.UserId = _userRepository.GetLoggedInUserId();
                _context.Goals.Add(goal);
                _context.SaveChanges();
                return goal;
            }
            return null;
        } // CreateGoal method ends


        //// read
        public IQueryable<Goal> GetAllGoals()
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Goals.Where(g => g.UserId == _userRepository.GetLoggedInUserId());
            }
            Goal[] noGoals = new Goal[0];
            return noGoals.AsQueryable();
        } // GetAllGoals method ends

        public Goal GetGoalById(int goalId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                Goal goal = _context.Goals
                    .Include(g => g.Tasks)
                    .FirstOrDefault(g => g.GoalId == goalId && g.UserId == _userRepository.GetLoggedInUserId());
                if (goal != null)
                {
                    goal.Tasks = goal.Tasks.OrderBy(t => t.TaskOrder);
                }
                return goal;
            }
            return null;
        } // GetGoalById method ends

        public IQueryable<string> GetAllCategories()
            => _context.Goals.Select(g => g.Type).Distinct();
        // GetAllCategories method ends
        public IQueryable<Goal> GetGoalsByKeyword(string keyword)
            => _context.Goals.Where(goal => goal.GoalName.Contains(keyword));
        // GetGoalsByKeyword method ends


        //// update
        public Goal UpdateGoal(Goal goal)
        {
            Goal goalToUpdate = GetGoalById(goal.GoalId);
            if (goalToUpdate != null)
            {
                goalToUpdate.GoalName = goal.GoalName;
                goalToUpdate.Priority = goal.Priority;
                goalToUpdate.Status = goal.Status;
                goalToUpdate.Type = goal.Type;
                goalToUpdate.StartDate = goal.StartDate;
                goalToUpdate.EndDate = goal.EndDate;
                goalToUpdate.Details = goal.Details;
                _context.SaveChanges();
            }
            return goalToUpdate;
        } // UpdateGoal method ends


        //// delete
        public bool DeleteGoal(Goal goal)
        {
            // Goal goalToDelete = _context.Goals.Find(goalId);
            Goal goalToDelete = GetGoalById(goal.GoalId);
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