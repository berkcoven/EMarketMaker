using AutoMapper;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using EMarketMaker.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace EMarketMaker.MVC.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IBasketProductService _basketProductService;
        public ShopController(SignInManager<IdentityUser> signInManager, IProductService productService, IMapper mapper, IBasketProductService basketProductService, IUserService userService)
        {
            _signInManager = signInManager;
            _productService = productService;
            _userService = userService;
            _mapper = mapper;
            _basketProductService = basketProductService;
        }
       
        public async Task<IActionResult> CsGOPackages()
        {
         
            var products = await _productService.GetProductsListWithCategoryId(1);

            return View(products);
        }
       
        public async Task<IActionResult> MinecraftPackages()
        {
            var products = await _productService.GetProductsListWithCategoryId(2);

            return View(products);
        }

        [HttpPost]
        public async Task<JsonResult> AddProductAsync(string id)
        {
            UserDto userDto = await _userService.GetUserDtoWithAspId(_signInManager.UserManager.GetUserAsync(User).Result.Id);
          
            BasketListDto basket = await _basketProductService.GetBasketWithUserId(userDto.Id);
            await _basketProductService.AddBasketProduct(basket.Basket.Id, Int32.Parse(id));

            var basketafter = await _basketProductService.AddProductToBasketWithBasketId(basket.Basket.Id, Int32.Parse(id));
            return Json(new { data = basketafter });

            //return Json(basketafter.ToJson());
        }

        [HttpPost]
        public async Task<JsonResult> GetBasketAsync()
        {
            UserDto userDto = await _userService.GetUserDtoWithAspId(_signInManager.UserManager.GetUserAsync(User).Result.Id);

            BasketListDto basket = await _basketProductService.GetBasketWithUserId(userDto.Id);
         
            return Json(new { data = basket });

            //return Json(basketafter.ToJson());
        }
        [HttpPost]
        public async Task<JsonResult> ClearBasketAsync()
        {
            UserDto userDto = await _userService.GetUserDtoWithAspId(_signInManager.UserManager.GetUserAsync(User).Result.Id);
            BasketListDto basket = await _basketProductService.GetBasketWithUserId(userDto.Id);
            if (_basketProductService.ClearBasket(basket.Basket.Id))
            {

                return Json(Ok());
            }
            return Json(false);
        }
    }
}
