﻿using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IGoalRepository
    {
        // create
        public Goal CreateGoal(Goal goal);


        // read
        public IQueryable<Goal> GetAllGoals();


        public Goal GetGoalById(int goalId);

        public IQueryable<string> GetAllCategories();
        public IQueryable<Goal> GetGoalsByKeyword(string keyword);


        // update
        public Goal UpdateGoal(Goal goal);


        // delete
        public bool DeleteGoal(Goal goal);


    } // class ends
} // namespace ends
