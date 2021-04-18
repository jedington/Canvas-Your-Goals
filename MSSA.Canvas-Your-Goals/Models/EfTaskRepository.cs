using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfTaskRepository : ITaskRepository
    {
        // fields
        private AppDbContext _context;


        // constructors
        public EfTaskRepository(AppDbContext context)
            => _context = context;
        // EfTaskRepository const ends

        
        // methods
        //// create
        public Task CreateTask(int goalId, Task task)
        {
            task.GoalId = goalId;
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }


        //// read
        public IQueryable<Task> GetAllTasks()
            => _context.Tasks; // F-Magic

        public IQueryable<Task> GetAllTasks(int goalId)
            => _context.Tasks.Where(t => t.GoalId == goalId);

        public Task GetTaskById(int taskId)
            => _context.Tasks.Find(taskId);


        //// update
        public Task UpdateTask(Task task)
        {
            Task taskToUpdate = _context.Tasks.Find(task.TaskId);
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
        }


        //// delete
        public bool DeleteTask(int taskId)
        {
            Task taskToDelete = GetTaskById(taskId);
            if (taskToDelete == null)
            {
                return false;
            }
            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
