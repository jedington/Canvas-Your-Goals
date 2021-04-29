using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Register(User user) // Add!
        {
            if (ModelState.IsValid)
            {
                _repository.CreateUser(user);
                return RedirectToAction("Index", new {userId = user.UserId});
            }
            return View(user);
        } // Register method ends


        //// Read
        public IActionResult Index(int userId)
        {
            User user = _repository.GetUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        } // Index method ends

        public IActionResult Profile(int userId)
        {
            User user = _repository.GetUserById(userId);
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
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", User.Identity);
            }
            return View(user);
        } // Login method ends

        [HttpGet]
        public IActionResult ForgotPassword()
            => View();
        [HttpPost]
        public IActionResult ForgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ResetPassword", User.Identity);
            }
            return View(user);
        } // ForgotPassword method ends


        //// update
        [HttpGet]
        public IActionResult Edit(int userId)
        {
            User user = _repository.GetUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateUser(user);
                return RedirectToAction("Profile", new {userId = user.UserId});
            }
            return View(user);
        } // ForgotPassword method ends

        [HttpGet]
        public IActionResult ResetPassword(int userId)
        {
            User user = _repository.GetUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult ResetPassword(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateUser(user);
                return RedirectToAction("Profile", new {userId = user.UserId});
            }
            return View(user);
        } // ResetPassword method ends


        //// delete
        [HttpGet]
        public IActionResult Delete(int userId)
        {
            User user = _repository.GetUserById(userId);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        } // Delete HttpGet method ends
        [HttpPost]
        public IActionResult DeleteAction(User user)
        {
            _repository.DeleteUser(user.UserId);
            return RedirectToAction("Login");
        } // Delete HttpPost method ends
    } // class ends
} // namespace ends
