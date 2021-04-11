using System;
using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class GoalController : Controller
    {
        [HttpGet]
        public IActionResult GoalList()
            // not created yet -- placeholder
            // go to database and pull user's goals
            // have View list all their goals
            => View();
        // GoalList method ends


        // Create
        [HttpGet]
        public IActionResult Add()
            => View();
        [HttpPost]
        public IActionResult Add(Goal addGoal)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details");
            }
            return View(addGoal);
        } // Add method ends


        // Read
        public IActionResult Details(int id)
        {
            // go to databasse and get 1 goal on the id
            // have view display that goal

            // pretend fake database
            Goal goalOne = new Goal
            {
                GoalId = 1,
                UserId = 1,
                Goalname = "MSSA Classes",
                Priority = "High",
                Status = "In Progress",
                Type = "Education",
                Startdate = Convert.ToDateTime("01-11-2021"),
                Enddate = Convert.ToDateTime("05-21-2021"),
                Details = "Working through the course!"
            };
            return View(goalOne);
        } // Details method ends


        // update
        [HttpGet]
        public IActionResult Edit()
        {
            Goal goalOne = new Goal
            {
                GoalId = 1,
                UserId = 1,
                Goalname = "MSSA Classes",
                Priority = "High",
                Status = "In Progress",
                Type = "Education",
                Startdate = Convert.ToDateTime("01/11/2021"),
                Enddate = Convert.ToDateTime("05/21/2021"),
                Details = "Working through the course!"
            };
            return View(goalOne);
        }
        [HttpPost]
        public IActionResult Edit(Goal editGoal)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details");
            }
            return View(editGoal);
        } // Edit method ends


        // delete


    } // class ends
} // namespace ends
