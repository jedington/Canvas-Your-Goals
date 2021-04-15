using System.Linq;
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
        // Create
        [HttpGet]
        public IActionResult Register()
            => View();
        [HttpPost]
        public IActionResult Register(User userReg)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateUser(userReg);
                return RedirectToAction("Index");
            }
            return View(userReg);
        } // Register method ends


        // Read
        public IActionResult Index()
            => View();
        // Index method ends

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
                return RedirectToAction("ResetPassword");
            }
            return View(userReq);
        } // ForgotPassword method ends


        // update
        [HttpGet]
        public IActionResult ResetPassword()
            => View();
        [HttpPost]
        public IActionResult ResetPassword(User userFetch)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateUser(userFetch);
                return RedirectToAction("Index",
                    new { user = userFetch.Password } );
            }
            return View(userFetch);
        } // ResetPassword method ends


        // delete


    } // class ends
} // namespace ends
