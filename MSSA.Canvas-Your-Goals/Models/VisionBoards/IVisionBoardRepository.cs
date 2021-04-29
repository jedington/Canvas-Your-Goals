using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IVisionBoardRepository
    {
        // create
        public VisionBoard CreateVisionBoard(VisionBoard vBoard);


        // read
        public IQueryable<VisionBoard> GetAllVisionBoards();

        public IQueryable<string> GetAllCategories();

        public VisionBoard GetVisionBoardById(int vBoardId);

        public IQueryable<VisionBoard> GetVisionBoardsByKeyword(string keyword);


        // update
        public VisionBoard UpdateVisionBoard(VisionBoard vBoard);


        // delete
        public bool DeleteVisionBoard(int vBoardId);

    } // class ends
} // namespace ends
