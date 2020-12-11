using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nwl_dotnetcore.Models;

namespace nwl_dotnetcore.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Name"] = "Patthapong Niamkerd";
            ViewData["Age"] = 2020-1999;
            return View();
        }

       // [Route("Home/Privacy/{txt}")]
        public IActionResult Privacy()
        {
            // ViewData["msg"] = "This is text :" +txt;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
