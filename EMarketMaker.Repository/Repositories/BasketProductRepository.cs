using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using EMarketMaker.Core.Repositories;
using EMarketMaker.Repository.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Repository.Repositories
{
    public class BasketProductRepository : GenericRepository<BasketProduct>, IBasketProductRepository
    {
        private readonly IMapper _mapper;
        public BasketProductRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<BasketListDto> AddProductBasketWithBasketId(int basketId, int productId)
        {
            BasketListDto basketListDto = new BasketListDto();
            var basket=await GetBasketWithBasketId(basketId);
           
            basket.TotalAmount = 0;
            var prolist =  GetProductsInBasket(basket.Id);
            foreach (var item in prolist)
            {
                basket.TotalAmount += item.Price;

            }
            _context.SaveChanges();
            basketListDto.Basket = basket;
            basketListDto.ProductList = prolist;
            return basketListDto;
        }

        public async Task<Basket> GetBasketWithBasketId(int basketId)
        {
               
            Basket basket = _context.Basket.ToList().FirstOrDefault(x => x.Id == basketId);
            return basket;
        }
        public List<ProductDto> GetProductsInBasket(int basketId)
        {
            List<BasketProduct> basketProducts = _context.BasketProducts.Where(x => x.BasketId == basketId).ToList();
           
            if (basketProducts != null)
            {
                List<ProductDto> proList = new List<ProductDto>();
                foreach (var item in basketProducts)
                {
                    
                    Product product = _context.Products.ToList().FirstOrDefault(x => x.Id == item.ProductId);
                    ProductDto productDto = _mapper.Map<ProductDto>(product);
                    proList.Add(productDto);


                }
                return proList;
            }
            else
            {

                List<ProductDto> proList = new List<ProductDto>();

            return proList;
            }
        }

        public async Task<BasketListDto> GetBasketWithUserId(int userId)
        {
            Basket basket =  _context.Basket.AsNoTracking().ToList().FirstOrDefault(x => x.userId == userId);
            BasketListDto basketListDto = new BasketListDto();
            if (basket != null)
            {
                basketListDto.Basket = basket;
                basketListDto.ProductList=GetProductsInBasket(basket.Id);
                return basketListDto;
            }
            else
            {
                
                Basket newBasket = new Basket();
                newBasket.userId = userId;
                basketListDto.ProductList = new List<ProductDto>();
                basketListDto.Basket = newBasket;
                //newBasket.ProductList = new List<ProductDto>();
                await _context.Basket.AddAsync(newBasket);
                await _context.SaveChangesAsync();
                return basketListDto;
            }
            //throw new NotImplementedException();
            //return await _context.BasketProducts.Include(x => x.basket).Include(x => x.product).Where(x => x. == categoryId).SingleOrDefaultAsync();
        }
    }
}
