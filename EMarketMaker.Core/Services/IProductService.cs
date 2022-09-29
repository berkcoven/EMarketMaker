using EMarketMaker.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
        Task<List<ProductWithCategoryDto>> GetProductsListWithCategory();
        Task<List<ProductWithCategoryDto>> GetProductsListWithCategoryId(int catId);
    }
}
