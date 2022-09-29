using EMarketMaker.Core.Models;
using EMarketMaker.Core.Services;
using EMarketMaker.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace EMarketMaker.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, IUserService userService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userService = userService;
        }
        [Route("")]
        [Authorize]
        public async Task<IActionResult> MainAsync()
        {
            

            var aspUser = await _signInManager.UserManager.GetUserAsync(User);
                        var user =  _userService.GetAllAsync().Result.Where(x=>x.AspId==aspUser.Id).FirstOrDefault();
            if (user != null)
            {
                return View();
            }

            User newUser = new User()
            {
                AspId = aspUser.Id,
                Name = aspUser.UserName,
                Mail = aspUser.Email,
                CreatedDate = DateTime.Now,
                Password=""

            };
            await _userService.AddAsync(newUser);

            return View();
        }

        public IActionResult Login()
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