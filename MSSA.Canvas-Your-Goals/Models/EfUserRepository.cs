using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfUserRepository : IUserRepository
    {
        // fields
        private AppDbContext _context;


        // constructors
        public EfUserRepository(AppDbContext context)
            => _context = context;
        // EfUserRepository const ends


        // methods
        //// create
        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        
        //// read
        public User GetUserById(int userId)
            //- User user = _context.Users
            //-     .Where(user => user.UserId == userId).FirstOrDefault();
            => _context.Users.Find(userId);
         // GetUserById method ends


        //// update
        public User UpdateUser(User user)
        {
            User userToUpdate = _context.Users.Find(user.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                userToUpdate.SecurityHint = user.SecurityHint;
                userToUpdate.SecurityAnswer = user.SecurityAnswer;
                _context.SaveChanges();
            }
            return userToUpdate;
        } // UpdateUser method ends


        //// delete
        public bool DeleteUser(int userId)
        {
            // Product userToDelete = _context.Users.Find(id);
            User userToDelete = GetUserById(userId);
            if (userToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteUser method ends

    } // class ends
} // namespace ends