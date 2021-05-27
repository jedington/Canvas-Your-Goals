using System.Linq;

namespace MSSA.Canvas_Your_Goals.Models
{
    public interface IUserRepository
    {
        // create
        public User CreateUser(User user);


        // read
        public IQueryable<User> GetAllUsers();

        public User GetUserByEmail(string email);

        public User GetUserById(int userId);

        public bool Login(User user);

        public void Logout();

        public bool IsUserLoggedIn();

        public int GetLoggedInUserId();

        public string GetLoggedInEmail();


        // update
        public User UpdateUser(User user);

        public bool ChangePassword(string currentPassword, string newPassword);

        public bool ResetPassword(string email);

        //- public void Send(string to, string subject, string body);


        // delete
        public bool DeleteUser(int userId);

        public bool DeleteUser(User user);
    } // class ends
} // namespace ends
