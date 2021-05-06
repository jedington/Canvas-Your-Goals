using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfTaskRepository : ITaskRepository
    {
        // fields
        private AppDbContext _context;
        private IUserRepository _userRepository;


        // constructors
        public EfTaskRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        } // EfTaskRepository const ends

        
        // methods
        //// create
        public Task CreateTask(Task task)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return task;
            }
            return null;
        } // CreateTask method ends


        //// read
        public IQueryable<Task> GetAllTasks(int goalId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Tasks.Where(t => t.Goal.UserId == _userRepository.GetLoggedInUserId());
            }
            Task[] noTasks = new Task[0];
            return noTasks.AsQueryable();
        } // GetAllTasks method ends

        public Task GetTaskById(int taskId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                Task task = _context.Tasks
                    .Include(t => t.Steps)
                    .FirstOrDefault(t => t.TaskId == taskId && t.Goal.UserId == _userRepository.GetLoggedInUserId());
                if (task != null)
                {
                    task.Steps = task.Steps.OrderBy(s => s.StepOrder);
                }
                return task;
            }
            return null;
        } // GetTaskById method ends


        //// update
        public Task UpdateTask(Task task)
        {
            Task taskToUpdate = GetTaskById(task.TaskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.TaskName = task.TaskName;
                taskToUpdate.TaskOrder = task.TaskOrder;
                taskToUpdate.Status = task.Status;
                taskToUpdate.StartDate = task.StartDate;
                taskToUpdate.EndDate = task.EndDate;
                taskToUpdate.Details = task.Details;
                _context.SaveChanges();
            }
            return taskToUpdate;
        } // UpdateTask method ends


        //// delete
        public bool DeleteTask(Task task)
        {
            Task taskToDelete = GetTaskById(task.TaskId);
            if (taskToDelete == null)
            {
                return false;
            }
            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteTask method ends
    } // class ends
} // namespace ends
