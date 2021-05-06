using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfStepRepository : IStepRepository
    {
        // fields
        private AppDbContext _context;
        private IUserRepository _userRepository;


        // constructors
        public EfStepRepository(AppDbContext context, IUserRepository userRepository)
        { 
            _context = context;
            _userRepository = userRepository;
        } // EfStepRepository const ends

        
        // methods
        //// create
        public Step CreateStep(Step step)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                _context.Steps.Add(step);
                _context.SaveChanges();
                return step;
            }
            return null;
        } // CreateStep method ends


        //// read
        public IQueryable<Step> GetAllSteps(int taskId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Steps.Where(s => s.Task.Goal.UserId == _userRepository.GetLoggedInUserId());
            }
            Step[] noSteps = new Step[0];
            return noSteps.AsQueryable();
        } // GetAllSteps method ends

        public Step GetStepById(int stepId)
        { 
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Steps.FirstOrDefault(s => s.StepId == stepId && s.Task.Goal.UserId == _userRepository.GetLoggedInUserId());
            }
            return null;
        } // GetStepById method ends

        //// update
        public Step UpdateStep(Step step)
        {
            Step stepToUpdate = GetStepById(step.StepId);
            if (stepToUpdate != null)
            {
                stepToUpdate.StepName = step.StepName;
                stepToUpdate.StepOrder = step.StepOrder;
                stepToUpdate.Status = step.Status;
                stepToUpdate.StartDate = step.StartDate;
                stepToUpdate.EndDate = step.EndDate;
                stepToUpdate.Details = step.Details;
                _context.SaveChanges();
            }
            return stepToUpdate;
        } // UpdateStep method ends


        //// delete
        public bool DeleteStep(Step step)
        {
            Step stepToDelete = GetStepById(step.StepId);
            if (stepToDelete == null)
            {
                return false;
            }
            _context.Steps.Remove(stepToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteStep method ends
    } // class ends
} // namespace ends
