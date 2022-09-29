using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Services
{
    public interface IBasketProductService:IService<BasketProduct>
    {
        Task<BasketListDto> GetBasketWithUserId(int userId);
        Task<BasketProduct> AddBasketProduct(int basketId,int productId);
       
        Task<BasketListDto> AddProductToBasketWithBasketId(int basketId,int productId);
        bool ClearBasket(int basketId);
    }
}
