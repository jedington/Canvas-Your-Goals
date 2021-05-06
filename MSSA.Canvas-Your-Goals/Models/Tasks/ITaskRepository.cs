using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface ITaskRepository
    {
        // create
        public Task CreateTask(Task addTask);

        // read
        public IQueryable<Task> GetAllTasks(int goalId);

        public Task GetTaskById(int taskId);


        // update
        public Task UpdateTask(Task task);


        // delete
        public bool DeleteTask(Task task);

    }
}
