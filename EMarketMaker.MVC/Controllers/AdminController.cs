using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EMarketMaker.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public AdminController(ICategoryService categoryService, IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }



        public async Task<IActionResult> AddProduct()
        {
            var categories = await _categoryService.GetAllAsync();
            ProductAddDto productAddDto = new ProductAddDto() { categoryDtos = _mapper.Map<List<CategoryDto>>(categories), ProductDto = new ProductDto() };
            return View(productAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            ModelState.Remove("categoryDtos");
            if (ModelState.IsValid)
            {

                await _productService.AddAsync(_mapper.Map<Product>(productAddDto.ProductDto));
                return RedirectToAction("Home");
            }
           
            var categories = await _categoryService.GetAllAsync();
            productAddDto.categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return View(productAddDto);
        }
    }
}
