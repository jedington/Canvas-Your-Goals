using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IUserRepository
    {
        // create
        public User CreateUser(User user);


        // read
        public User GetUserById(int userId);


        // update
        public User UpdateUser(User user);


        // delete
        public bool DeleteUser(int userId);
    } // class ends
} // namespace ends
