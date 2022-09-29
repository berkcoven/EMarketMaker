using EMarketMaker.Core;
using EMarketMaker.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {

            //Eager Loading product alırken category alınca 
            //Lazy Loading lazm olduğunda category alındığında
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithCategoryId(int catId)
        {
            return await _context.Products.Where(x=>x.CategoryId==catId).ToListAsync();
        }
    }
}
