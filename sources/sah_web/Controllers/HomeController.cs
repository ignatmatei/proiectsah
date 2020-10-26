using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using proiect_sah;
using sah;
using sah_web.Models;

namespace sah_web.Controllers
{
    public class HomeController : Controller
    {
        static Game G = new Game();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            G.PlayerWhite.color = Color.White;
            G.PlayerBlack.color = Color.Black;
            G.PlayerWhite.name = "Andrei";
            G.PlayerBlack.name = "Matei" ;
            return View(G);
        }
        //https://localhost:5001/Home/IsValid?first=e2&last=e4
        public bool IsValid(string first, string last)
        {
          var coloanainit = Enum.Parse<column>(first.Substring(0, 1), true);
          var linieinit = int.Parse(first.Substring(1, 1));
          var coloanafin = Enum.Parse<column>(last.Substring(0, 1), true);
          var liniefin = int.Parse(last.Substring(1, 1));
            if (G.board.IsLegal(linieinit, coloanainit, liniefin, coloanafin))
            {
                G.board.MovePiece(linieinit, coloanainit, liniefin, coloanafin);
                return true;
            }
            return false;
       
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
