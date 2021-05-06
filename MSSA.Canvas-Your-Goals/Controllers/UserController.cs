using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class UserController : Controller
    {
        // this entire controller--along with it's relevant model/views needs modification
        private IUserRepository _repository;


        // constructors
        public UserController(IUserRepository repository)
            => _repository = repository;
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
                User newUser = _repository.CreateUser(user);
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
            User user = _repository.GetUserById(_repository.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Index method ends

        public IActionResult Profile()
        {
            User user = _repository.GetUserById(_repository.GetLoggedInUserId());
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
            bool loggedIn = _repository.Login(user);
            if (loggedIn && ModelState.IsValid)
            {
                return RedirectToAction("Index", "User");
            }
            return View(user);
        } // Login method ends

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Index", "Home");
        } // Logout method ends

        [HttpGet]
        public IActionResult ForgotPassword()
            => View();
        [HttpPost]
        public IActionResult ForgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ResetPassword", new {userId = user.UserId});
            }
            return View(user);
        } // ForgotPassword method ends


        //// update
        [HttpGet]
        public IActionResult Edit()
        {
            User user = _repository.GetUserById(_repository.GetLoggedInUserId());
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
                _repository.UpdateUser(user);
                return RedirectToAction("Profile");
            }
            return View(user);
        } // Edit HttpPost method ends

        [HttpGet]
        public IActionResult ChangePassword()
            => View();
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM changePwd)
        {
            if (ModelState.IsValid)
            {
                bool success = _repository
                    .ChangePassword(changePwd.CurrentPassword, changePwd.NewPassword);
                if (success)
                {
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Unable to Change Password");
                return View(changePwd);
            }
            return View(changePwd);
        } // ChangePassword method ends

        [HttpGet]
        public IActionResult ResetPassword()
            => View();
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM resetPwd)
        {
            if (ModelState.IsValid)
            {
                bool success = _repository
                    .ResetPassword(resetPwd.Email, resetPwd.NewPassword);
                if (success)
                {
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Unable to Change Password");
                return View(resetPwd);
            }
            return View(resetPwd);
        } // ChangePassword method ends


        //// delete
        [HttpGet]
        public IActionResult Delete()
        {
            User user = _repository.GetUserById(_repository.GetLoggedInUserId());
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult Delete(User user)
        {
            _repository.DeleteUser(user);
            return RedirectToAction("Login");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
