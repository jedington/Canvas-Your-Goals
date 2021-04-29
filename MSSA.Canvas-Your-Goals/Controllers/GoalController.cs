﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class GoalController : Controller
    {
        // fields
        private int _pageSize = 10;
        private IGoalRepository _repository;


        // constructors
        public GoalController(IGoalRepository repository)
            => _repository = repository;
        // GoalController const ends

        
        // methods
        //// Create
        [HttpGet]
        public IActionResult Add()
            => View();
        [HttpPost]
        public IActionResult Add(int userId, Goal goal)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateGoal(userId, goal);
                return RedirectToAction("Details", new {goalId = goal.GoalId});
            }
            return View(goal);
        } // Register method ends


        //// Read
        public IActionResult Index(int userId, int goalPage = 1)
        {
            IQueryable<Goal> allGoals = _repository.GetAllGoals(userId);
            IQueryable<Goal> someGoals = allGoals
                .OrderBy(goal => goal.GoalId)
                .Skip((goalPage - 1) * _pageSize)
                .Take(_pageSize);
            PagingInfo pInfo = new PagingInfo
            {
                TotalItems = allGoals.Count(),
                CurrentPage = goalPage,
                ItemsPerPage = _pageSize
            };
            GoalListViewModel gLvM = new GoalListViewModel
            {
                PagingInfo = pInfo,
                Goals = someGoals
            };
            return View(allGoals);
        } // Index method ends
        
        public IActionResult Details(int goalId)
        {
            Goal goal = _repository.GetGoalById(goalId);
            if (goal != null)
            {
                return View(goal);
            }
            return RedirectToAction("Index");
        } // Details method ends


        //// Update
        [HttpGet]
        public IActionResult Edit(int goalId)
        {
            Goal goal = _repository.GetGoalById(goalId);
            if (goal != null)
            {
                return View(goal);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Goal goal)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateGoal(goal);
                return RedirectToAction("Details", new {goalId = goal.GoalId});
            }
            return View(goal);
        } // Edit method ends


        //// Delete
        [HttpGet]
        public IActionResult Delete(int goalId)
        {
            Goal goal = _repository.GetGoalById(goalId);
            if (goal != null)
            {
                return View(goal);
            }
            return RedirectToAction("Index");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult DeleteAction(Goal goal)
        {
            _repository.DeleteGoal(goal.GoalId);
            return RedirectToAction("Index");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
