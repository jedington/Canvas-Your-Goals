using Microsoft.AspNetCore.Mvc;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class UserController : Controller
    {
        private int _pageSize = 10;
        private IUserRepository _repository;


        // constructors
        public UserController(IUserRepository repository)
            => _repository = repository;
        // UserController const ends
        

        // methods
        // create
        [HttpGet]
        public IActionResult Register()
            => View();
        [HttpPost]
        public IActionResult Register(User userReg)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(userReg);
        } // Register method ends


        // read
        [HttpGet]
        public IActionResult Login()
            => View();
        [HttpPost]
        public IActionResult Login(User userLog)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(userLog);
        } // Login method ends

        [HttpGet]
        public IActionResult ForgotPassword()
            => View();
        [HttpPost]
        public IActionResult ForgotPassword(User userReq)
        {
            if (ModelState.IsValid)
            {
                return View("ResetPassword");
            }
            return View(userReq);
        } // ForgotPassword method ends


        // update
        [HttpGet]
        public IActionResult ResetPassword()
            => View();
        [HttpPost]
        public IActionResult ResetPassword(User userPwd)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(userPwd);
        } // ResetPassword method ends


        // delete


    } // class ends
} // namespace ends
