using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MSSA.Canvas_Your_Goals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
            => _logger = logger;
        // HomeController const ends

        public IActionResult Index()
            => View();
        // Index method ends

        public IActionResult Privacy()
            => View();
        // Privacy method ends

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View();
        // Error method ends
    } // class ends
} // namespace ends
