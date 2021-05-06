using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IStepRepository
    {
        // create
        public Step CreateStep(Step addStep);

        // read
        public IQueryable<Step> GetAllSteps(int taskId);

        public Step GetStepById(int stepId);


        // update
        public Step UpdateStep(Step step);


        // delete
        public bool DeleteStep(Step step);

    }
}
