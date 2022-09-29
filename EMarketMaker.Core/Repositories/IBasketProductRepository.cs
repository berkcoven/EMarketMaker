using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Repositories
{
    public interface IBasketProductRepository:IGenericRepository<BasketProduct>
    {
        Task<BasketListDto> GetBasketWithUserId(int userId);
        Task<BasketListDto> AddProductBasketWithBasketId(int basketId,int productId);
    }
}
