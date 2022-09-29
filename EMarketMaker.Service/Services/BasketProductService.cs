using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using EMarketMaker.Core.Repositories;
using EMarketMaker.Core.Services;
using EMarketMaker.Core.UnitOfWorks;
using EMarketMaker.Repository.Migrations;
using EMarketMaker.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Service.Services
{
    public class BasketProductService : Service<BasketProduct>, IBasketProductService
    {
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IGenericRepository<BasketProduct> _repository;
        private readonly IGenericRepository<Basket> _brepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketProductService(IGenericRepository<BasketProduct> repository,IGenericRepository<Basket> brepo, IUnitOfWork unitOfWork, IBasketProductRepository basketProductRepository, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _basketProductRepository = basketProductRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _repository = repository;
            _brepository = brepo;   
        }

        public async Task<BasketProduct> AddBasketProduct(int basketId, int productId)
        {
            try
            {
                BasketProduct basketProduct = new BasketProduct();
                basketProduct.BasketId = basketId;
                //basketProduct.Basket= await _brepository.GetByIdAsync(basketId);
                basketProduct.ProductId = productId;
                //basketProduct.Product= await _productRepository.GetByIdAsync(productId);
                
               await AddAsync(basketProduct);
                
                //await _unitOfWork.CommitAsync();
                 return basketProduct;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<BasketListDto> AddProductToBasketWithBasketId(int basketId, int productId)
        {
            BasketListDto basket =await _basketProductRepository.AddProductBasketWithBasketId(basketId,productId);
           
          
            return basket;

        }

        public  bool ClearBasket(int basketId)
        {
            Basket basket = _brepository.Where(x=>x.Id==basketId).FirstOrDefault();
            basket.TotalAmount = 0;
            _brepository.Update(basket);
            List<BasketProduct> basketPros = _basketProductRepository.Where(x=>x.BasketId==basketId).ToList();
            foreach (var item in basketPros)
            {
                _basketProductRepository.Remove(item);
            }
             _unitOfWork.Commit();
            return true;
        }

        public async Task<BasketListDto> GetBasketWithUserId(int userId)
        {
            var basket = await _basketProductRepository.GetBasketWithUserId(userId);
            return basket;
        }
    }
}
