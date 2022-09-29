using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Services;
using EMarketMaker.Web.Views.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMarketMaker.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {

            return View(new LoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var user = _userService.GetSingleUserWithMailPass(loginDto.Mail, loginDto.Password);
            if (user.Result != null)
            {
                
            return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

    
    }
}
