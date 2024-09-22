using FinalProjectWeek9.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeek9.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Privacy
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Home/About
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        // GET: /Home/Contact
        [HttpGet]
        public IActionResult Contact()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        // GET: /Home/Services
        [HttpGet]
        public IActionResult Services()
        {
            var model = new ServicesViewModel
            {
                Services = new[] { "Service 1", "Service 2", "Service 3" }
            };
            return View(model);
        }
    }
}
