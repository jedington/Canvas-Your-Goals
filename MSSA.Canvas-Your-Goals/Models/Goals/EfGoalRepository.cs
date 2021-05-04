using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public Goal CreateGoal(Goal goal)
        {
            try
            {
                _context.Goals.Add(goal);
                _context.SaveChanges();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception e)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
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
            => _context.Goals.Select(g => g.Type).Distinct();
        // GetAllCategories method ends

        public Goal GetGoalById(int goalId) 
            => _context.Goals
                //- .Include(g => g.User)
                .Include(g => g.Tasks.OrderBy(t => t.TaskOrder))
                .FirstOrDefault(g => g.GoalId == goalId);
        // GetGoalById method ends

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
                try
                {
                    _context.SaveChanges();
                }
                #pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
                #pragma warning restore CS0168 // Variable is declared but never used
                {
                    return null;
                }
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