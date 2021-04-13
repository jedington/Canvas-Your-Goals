using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IUserRepository
    {
        // create
        public User CreateUser(User user);


        // read
        public IQueryable<User> GetAllUsers();

        public IQueryable<string> GetAllCategories();

        public User GetUserById(int productId);

        public IQueryable<User> GetUsersByKeyword(string keyword);


        // update
        public User UpdateUser(User user);


        // delete
        public bool DeleteUser(int id);


    } // class ends
} // namespace ends
