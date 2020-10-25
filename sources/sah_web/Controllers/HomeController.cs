using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proiect_sah;
using sah;
using sah_web.Models;

namespace sah_web.Controllers
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
            Game G = new Game();
            G.PlayerWhite.color = Color.White;
            G.PlayerBlack.color = Color.Black;
            G.PlayerWhite.name = "Andrei";
            G.PlayerBlack.name = "Matei" ;
            return View(G);
        }
        //https://localhost:5001/Home/IsValid?first=e2&last=e4
        public bool IsValid(string first, string last)
        {
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
