using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class UserController : Controller
    {
        // this entire controller--along with it's relevant model/views needs modification
        private IUserRepository _repos;


        // constructors
        public UserController(IUserRepository repository)
            => _repos = repository;
        // UserController const ends
        

        // methods
        //// Create
        [HttpGet]
        public IActionResult Register() // Add!
            => View();
        [HttpPost]
        public IActionResult Register(RegisterVM userReg) // Add!
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.IsAdmin = false;
                user.Email = userReg.Email;
                user.Password = userReg.Password;
                user.SecurityHint = userReg.SecurityHint;
                user.SecurityAnswer = userReg.SecurityAnswer;
                User newUser = _repos.CreateUser(user);
                if (newUser == null)
                {
                    ModelState.AddModelError("", "This user already exists!");
                    return View(userReg);
                }
                return RedirectToAction("Index", "User");
            }
            return View(userReg);
        } // Register method ends


        //// Read
        public IActionResult Index()
        {
            User user = _repos.GetUserById(_repos.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Index method ends

        public IActionResult Profile()
        {
            User user = _repos.GetUserById(_repos.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Details method ends

        [HttpGet]
        public IActionResult Login()
            => View();
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool loggedIn = _repos.Login(user);
            if (loggedIn && ModelState.IsValid)
            {
                return RedirectToAction("Index", "User");
            }
            return View(user);
        } // Login method ends

        public IActionResult Logout()
        {
            _repos.Logout();
            return RedirectToAction("Index", "Home");
        } // Logout method ends


        //// update
        [HttpGet]
        public IActionResult Edit()
        {
            User user = _repos.GetUserById(_repos.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Edit HttpGet method ends
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _repos.UpdateUser(user);
                return RedirectToAction("Profile");
            }
            return View(user);
        } // Edit HttpPost method ends

        [HttpGet]
        public IActionResult ChangePassword()
        {
            User user = _repos.GetUserById(_repos.GetLoggedInUserId());
            if (user != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        } // ChangePassword HttpGet method ends
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM changePwd)
        {
            if (ModelState.IsValid)
            {
                bool success = _repos.ChangePassword(changePwd.CurrentPassword, changePwd.NewPassword);
                if (success)
                {
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Unable to Change Password");
                return View(changePwd);
            }
            return View(changePwd);
        } // ChangePassword HttpPost method ends

        [HttpGet]
        public IActionResult ResetPassword()
            => View();
        // ResetPassword HttpGet method ends
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM resetPwd)
        {
            if (ModelState.IsValid)
            {
                User user = _repos.GetUserByEmail(resetPwd.Email);
                bool success = _repos.ResetPassword(resetPwd.Email);
                if (success)
                {
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Unable to Reset Password...");
                return View(resetPwd);
            }
            return View(resetPwd);
        } // ResetPassword Http method ends


        //// delete
        [HttpGet]
        public IActionResult Delete()
        {
            User user = _repos.GetUserById(_repos.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult Delete(User user)
        {
            _repos.DeleteUser(user);
            return RedirectToAction("Login");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
