using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public Task CreateTask(Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception e)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
            return task;
        } // CreateTask method ends


        //// read
        public IQueryable<Task> GetAllTasks()
            => _context.Tasks; // F-Magic
        // GetAllTasks method ends

        public IQueryable<Task> GetAllTasks(int goalId)
            => _context.Tasks.Where(t => t.GoalId == goalId);
        // GetAllTasks method ends

        public Task GetTaskById(int taskId)
            => _context.Tasks
                .Include(t => t.Goal)
                .FirstOrDefault(t => t.TaskId == taskId);
        // GetTaskById method ends

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
