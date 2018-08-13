using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PacMan2._0;
using PacWeb.Hubs;
using PacWeb.Models;

namespace PacWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeFirstContext _context;
        private readonly IHubContext<PacHub> _hubContext;
        private readonly ActiveGameCollection activeGameCollection;

        public HomeController(IHubContext<PacHub> hubContext, ActiveGameCollection activeGameCollection)
        {
            this.activeGameCollection = activeGameCollection;
            _hubContext = hubContext;
            _context = new CodeFirstContext();
        }
        public IActionResult Index()
        {
            var id = Guid.NewGuid().ToString();
            ViewBag.Id = id;
            var game = new Game(id);
            activeGameCollection.AddGame(id, new GameConnections(game, _hubContext));

            var query = from b in _context.PacMan
                        orderby b.Score descending
                        select b;
            return View(query.ToList());

        }

        public IActionResult Results()
        {
            var query = from b in _context.PacMan
                        orderby b.Score descending
                        select b;
            return View(query.ToList());
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
