using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MSSA.Canvas_Your_Goals.Models
{
    public class EfUserRepository : IUserRepository
    {
        // fields
        private AppDbContext _context;
        private ISession _session;

        // constructors
        public EfUserRepository(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _session = httpContext.HttpContext.Session;
        } // EfUserRepository const ends


        // methods
        //// create
        public User CreateUser(User user)
        {
            user.Password = EncryptPassword(user.Password);
            User existingUser = GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                return null;
            }
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        } // CreateUser method ends
        

        //// read
        public IQueryable<User> GetAllUsers()
            => _context.Users;
        // GetAllUsers method ends

        public User GetUserByEmail(string email)
            => _context.Users.FirstOrDefault(u => u.Email == email);
        // GetUserByEmail method ends

        public User GetUserById(int userId)
            => _context.Users.FirstOrDefault(u => u.UserId == userId);
        // GetUserById method ends

        public bool Login(User user)
        {
            string encryptPwd = EncryptPassword(user.Password);
            User existingUser = _context.Users.FirstOrDefault
                (u => u.Email == user.Email && u.Password == encryptPwd);
            if (existingUser == null || existingUser.Password != encryptPwd)
            {
                return false;
            }
            _session.SetInt32("userid", existingUser.UserId);
            _session.SetString("email", user.Email);
            return true;
        } // Login method ends
        public void Logout()
        {
            _session.Remove("userid");
            _session.Remove("email");
        }

        public bool IsUserLoggedIn()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return false;
            }
            return true;
        } // IsUserLoggedIn method ends

        public int GetLoggedInUserId()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return -1;
            }
            return userId.Value;
        } // GetLoggedInUserId method ends

        public string GetLoggedInEmail()
        {
            return _session.GetString("email");
        } // GetLoggedInEmail


        //// update
        public User UpdateUser(User user)
        {
            User userToUpdate = GetUserById(user.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.SecurityHint = user.SecurityHint;
                userToUpdate.SecurityAnswer = user.SecurityAnswer;
                _context.SaveChanges();
            }
            return userToUpdate;
        } // UpdateUser method ends

        public bool ChangePassword(string currentPassword, string newPassword)
        {
            if (!IsUserLoggedIn())
            {
                return false;
            }
            User userToUpdate = GetUserById(GetLoggedInUserId());
            if (userToUpdate != null && userToUpdate.Password == EncryptPassword(currentPassword))
            {
                userToUpdate.Password = EncryptPassword(newPassword);
                _context.SaveChanges();
                return true;
            }
            return false;
        } // ChangePassword method ends

        public bool ResetPassword(string email)
        {
            if (IsUserLoggedIn())
            {
                return false;
            }
            User userToUpdate = GetUserByEmail(email);
            if (userToUpdate != null)
            {
                string newPassword = GenRandomPassword();
                Send(email, "Canvas Your Goals; Password Change", $"{email}, your password has been changed to: {newPassword}. Please access your account to change your password to your preference.");
                userToUpdate.Password = EncryptPassword(newPassword);
                _context.SaveChanges();
                return true;
            }
            return false;
        } // ChangePassword method ends


        //// delete
        public bool DeleteUser(int userId)
        {
            User userToDelete = GetUserById(userId);
            if (userToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        } // DeleteUser (UserId) method ends
        public bool DeleteUser(User user)
            => DeleteUser(user.UserId);
        // DeleteUser (User) method ends


        ////// private methods
        private string EncryptPassword(string pwd)
        {
            SHA256 hashAlgo = SHA256.Create();
            byte[] pwdArray = Encoding.ASCII.GetBytes(pwd);
            pwdArray[0] += 3; pwdArray[2] -= 6; pwdArray[4] += 1;
            byte[] encryptPwdArray = hashAlgo.ComputeHash(pwdArray);
            string result = BitConverter.ToString(encryptPwdArray);
            result = result.Replace("-", "");
            return result;
        } // EncryptPassword
        private string GenRandomPassword()
        {
            Random rng = new Random();
            string result = "";
            while (result.Length < 13)
            {
                result = result + (char)rng.Next(33, 126);
            }
            return result;
        } // GenerateRandomPassword

        private void Send(string to, string subject, string body)
        {
            string emailAccount = System.Environment.GetEnvironmentVariable("VisionBoardEmailAccount");
            string emailPassword = System.Environment.GetEnvironmentVariable("VisionBoardEmailPassword");

            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress(emailAccount);
                email.To.Add(to);
                email.Bcc.Add(emailAccount);
                email.Subject = subject;
                email.Body = body;
                email.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential
                    (emailAccount, emailPassword);
                smtp.EnableSsl = true;
                smtp.Send(email);

            }
            catch (Exception e)
            {
                // look at what is in 'e'
            }
        }

    } // class ends
} // namespace ends