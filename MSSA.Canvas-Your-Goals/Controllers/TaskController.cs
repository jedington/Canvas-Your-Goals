using System;
using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class TaskController : Controller
    {
        // fields
        private ITaskRepository _repos;


        // constructors
        public TaskController(ITaskRepository repository)
            => _repos = repository;
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
                _repos.CreateTask(task);
                return RedirectToAction("Details", new {taskId = task.TaskId});
            }
            return View(task);
        } // Register method ends


        //// Read
        public IActionResult Details(int taskId)
        {
            Task task = _repos.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "User");
        } // Details method ends


        //// Update
        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            Task task = _repos.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "User");
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
                _repos.UpdateTask(task);
                return RedirectToAction("Details", new {taskId = task.TaskId});
            }
            return View(task);
        } // Edit method ends


        //// Delete
        [HttpGet]
        public IActionResult Delete(int taskId)
        {
            Task task = _repos.GetTaskById(taskId);
            if (task != null)
            {
                return View(task);
            }
            return RedirectToAction("Index", "User");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _repos.DeleteTask(task);
            return RedirectToAction("Index", "Goal");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
