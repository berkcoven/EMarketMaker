using EMarketMaker.MVCUser.Data;
using EMartketMaker.MVCUser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMartketMaker.MVCUser.Controllers
{
    public class HomeController : Controller
    {
        private readonly oyntch_nONf6RNContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, oyntch_nONf6RNContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var x = _db.StorePlayers.ToList();

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