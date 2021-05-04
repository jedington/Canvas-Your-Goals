using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class TaskController : Controller
    {
        // fields
        private int _pageSize = 10;
        private ITaskRepository _repository;


        // constructors
        public TaskController(ITaskRepository repository)
            => _repository = repository;
        // TaskController const ends


        // methods
        //// Create
        [HttpGet]
        public IActionResult Add(int goalId)
            => View(new Task
            {
                GoalId = goalId, 
                StartDate = DateTime.Now.Date
            });
        [HttpPost]
        public IActionResult Add(Task task)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateTask(task);
                return RedirectToAction("Details", new {taskId = task.TaskId});
            }
            return View(task);
        } // Register method ends


        public IActionResult Index(int goalId, int taskPage = 1)
        {
            IQueryable<Task> allTasks = _repository.GetAllTasks(goalId);
            //- IQueryable<Task> someTasks = allTasks
            //-     .OrderBy(task => task.TaskId)
            //-     .Skip((taskPage - 1) * _pageSize)
            //-     .Take(_pageSize);
            //- PagingInfo pInfo = new PagingInfo
            //- {
            //-     TotalItems = allTasks.Count(),
            //-     CurrentPage = taskPage,
            //-     ItemsPerPage = _pageSize
            //- };
            //- TaskListViewModel tLvM = new TaskListViewModel
            //- {
            //-     PagingInfo = pInfo,
            //-     Tasks = someTasks
            //- };
            return View(allTasks);
        } // Index method ends
        
        public IActionResult Details(int taskId)
        {
            Task task = _repository.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "Goal");
        } // Details method ends


        //// Update
        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            Task task = _repository.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "Goal");
        } // Edit HttpGet method ends
        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if (task.StartDate > task.EndDate)
            {
                ModelState.AddModelError("", "Start Date must be older than the End Date");
            }
            if (ModelState.IsValid)
            {
                _repository.UpdateTask(task);
                return RedirectToAction("Details", new {taskId = task.TaskId});
            }
            return View(task);
        } // Edit method ends


        //// Delete
        [HttpGet]
        public IActionResult Delete(int taskId)
        {
            Task task = _repository.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "Goal");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _repository.DeleteTask(task);
            return RedirectToAction("Details", "Goal", new {task.Goal.GoalId});
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
