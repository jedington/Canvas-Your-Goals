using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfVisionBoardRepository : IVisionBoardRepository
    {
        // fields
        private AppDbContext _context;


        // constructors
        public EfVisionBoardRepository(AppDbContext context)
            => _context = context;
        // EfVisionBoardRepository const ends


        // methods
        //// create
        public VisionBoard CreateVisionBoard(VisionBoard vBoard)
        {
            _context.VisionBoards.Add(vBoard);
            _context.SaveChanges();
            return vBoard;
        } // CreateVisionBoard method ends
        
        //// read
        public IQueryable<VisionBoard> GetAllVisionBoards()
            => _context.VisionBoards; // F-Magic
        // GetAllVisionBoards method ends

        public IQueryable<string> GetAllCategories()
            => _context.VisionBoards.Select(p => p.VisionName)
                                .Distinct();
        // GetAllCategories method ends

        public VisionBoard GetVisionBoardById(int vBoardId)
            //- VisionBoard vBoard = _context.VisionBoards
            //-     .Where(vBoard => vBoard.VisionBoardId == vBoardId).FirstOrDefault();
            => _context.VisionBoards.Find(vBoardId);
         // GetGoalById method ends

        public IQueryable<VisionBoard> GetVisionBoardsByKeyword(string keyword)
            //- IQueryable<VisionBoard> vBoard = _context.VisionBoards
            //-     .Where(vBoard => vBoard.Name.Contains(keyword));
            => _context.VisionBoards.Where(vBoard => vBoard.VisionName.Contains(keyword));
        // GetGoalsByKeyword method ends

        //// update
        public VisionBoard UpdateVisionBoard(VisionBoard vBoard)
        {
            VisionBoard vBoardToUpdate = _context.VisionBoards.Find(vBoard.VisionBoardId);
            if (vBoardToUpdate != null)
            {
                vBoardToUpdate.VisionName = vBoard.VisionName;
                _context.SaveChanges();
            }
            return vBoardToUpdate;
        } // UpdateGoal method ends


        //// delete
        public bool DeleteVisionBoard(int id)
        {
            // Goal goalToDelete = _context.Goals.Find(id);
            VisionBoard vBoardToDelete = GetVisionBoardById(id);
            if (vBoardToDelete == null)
            {
                return false;
            }
            _context.VisionBoards.Remove(vBoardToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteGoal method ends
    } // class ends
} // namespace ends

