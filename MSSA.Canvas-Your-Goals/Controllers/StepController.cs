using System;
using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class StepController : Controller
    {
        // fields
        private IStepRepository _repos;


        // constructors
        public StepController(IStepRepository repository)
            => _repos = repository;
        // StepController const ends


        // methods
        //// Create
        [HttpGet]
        public IActionResult Add(int taskId)
            => View(new Step
            {
                TaskId = taskId, 
                StartDate = DateTime.Now.Date
            });
        [HttpPost]
        public IActionResult Add(Step step)
        {
            if (ModelState.IsValid)
            {
                _repos.CreateStep(step);
                return RedirectToAction("Details", new {stepId = step.StepId});
            }
            return View(step);
        } // Register method ends


        //// Read
        public IActionResult Details(int stepId)
        {
            Step step = _repos.GetStepById(stepId);
            if (step != null)
            {
                return View(step);
            }
            return RedirectToAction("Index", "User");
        } // Details method ends


        //// Update
        [HttpGet]
        public IActionResult Edit(int stepId)
        {
            Step step = _repos.GetStepById(stepId);
            if (step != null)
            {
                return View(step);
            }
            return RedirectToAction("Index", "User");
        } // Edit HttpGet method ends
        [HttpPost]
        public IActionResult Edit(Step step)
        {
            if (step.StartDate > step.EndDate)
            {
                ModelState.AddModelError("", "Start Date must be older than the End Date");
            }
            if (ModelState.IsValid)
            {
                _repos.UpdateStep(step);
                return RedirectToAction("Details", new {stepId = step.StepId});
            }
            return View(step);
        } // Edit method ends


        //// Delete
        [HttpGet]
        public IActionResult Delete(int stepId)
        {
            Step step = _repos.GetStepById(stepId);
            if (step != null)
            {
                return View(step);
            }
            return RedirectToAction("Index", "User");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult Delete(Step step)
        {
            _repos.DeleteStep(step);
            return RedirectToAction("Index", "Goal");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
