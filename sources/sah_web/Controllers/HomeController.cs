using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using proiect_sah;
using sah;
using sah_web.Classes;
using sah_web.Models;

namespace sah_web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static List<Challenges> AllChallenges;
        static  HomeController()
        {
            AllChallenges = new List<Challenges>();
        }
        public bool NewGame()
        {
            G = new Game();
            return true;
        }
        static Game G = new Game();
        /// <summary>
        /// g = new game
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
                       
        public IActionResult Index()
        {
            string UserName = User.Claims.First().Value;
            var exists = AccountController.Usernames.FirstOrDefault(it => it == UserName);
            if(exists == null)
            {
                AccountController.Usernames.Add(UserName);
            }
            return View("MainPage");
            G.PlayerWhite.color = Color.White;
            G.PlayerBlack.color = Color.Black;
            if (G.PlayerWhite.name == null) G.PlayerWhite.name = User.Claims.First().Value;
            else
            {
                if (G.PlayerBlack.name == null) G.PlayerBlack.name = User.Claims.First().Value;
            }
            return View(G);
        }
        //https://localhost:5001/Home/IsValid?first=e2&last=e4
        public bool IsValid(string first, string last , char pl =' ')
        {
          var coloanainit = Enum.Parse<column>(first.Substring(0, 1), true);
          var linieinit = int.Parse(first.Substring(1, 1));
          var coloanafin = Enum.Parse<column>(last.Substring(0, 1), true);
          var liniefin = int.Parse(last.Substring(1, 1));
          
            if (G.board.IsLegal(linieinit, coloanainit, liniefin, coloanafin))
            {
                G.board.MovePiece(linieinit, coloanainit, liniefin, coloanafin, pl);
                return true;
            }
            return false;
       
        }
        [HttpPost]
        public IActionResult Index(string ChallengeName)
        {
            int i;
            for (i = 0; i < AccountController.Usernames.Count; i++)
            {
                if(AccountController.Usernames[i] == ChallengeName)
                {
                    var newChallenge = new Challenges();
                    newChallenge.State = ChallengeState.Starting;
                    newChallenge.Challenger = User.Claims.First().Value;
                    newChallenge.Challengee = ChallengeName;
                    AllChallenges.Add(newChallenge);
                    return RedirectToAction("WaitingForAccept");
                   // return Content("Am gasit " + ChallengeName);
                }
            }
            return Content("User Invalid " + ChallengeName);
        }
        public IActionResult PendingChallenges()
        {
            var challengeUser = AllChallenges
                .Where(it => it.Challengee == User.Claims.First().Value)
                .ToList();

            return View(challengeUser);
        }
        [HttpPost]
        public IActionResult PendingChallenges(string challenger , string state)
        {
            return Content("Am primit challenger " + challenger + " si state " + state);
        }
        public IActionResult WaitingForAccept()
        {
            return View();
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
