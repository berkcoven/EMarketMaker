using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Repositories;
using EMarketMaker.Core.Services;
using EMarketMaker.Core.UnitOfWorks;
using EMarketMaker.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        //veritabanına sürekli çağırıda bulunmamk için
        //decorator design pattern çok yakın olan proxy desing pattern bu yapıyı bozmadan farklı serviceler kullanmak

        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            //out _ geri dönün değeri memoryde tutmak istemediğim için _
            if(!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                //cache boş işe doldur
                _memoryCache.Set(CacheProductKey, _repository.GetProductsWithCategory().Result);//Result çünkü async sync yaptık
            }

        }
    
        public async Task<Product> AddAsync(Product entity)//çok sık erişmek istediğim ama çok değiştirmiyceğim yerlerde cache en uygun
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;  
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
           return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).Any());
            
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).AsEnumerable());
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"{typeof(Product).Name} not found.");
            }
            return Task.FromResult(product);
        }

        public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
            var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Task.FromResult( CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsWithCategoryDto));
        }

        public async Task RemoveAsync(Product entity)
        {
             _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
             _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
             _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }
        public Task CacheAllProductsAsync()
        {
            return Task.FromResult(_memoryCache.Set(CacheProductKey, _repository.GetAll().ToListAsync().Result));
        }

        public Task<List<ProductWithCategoryDto>> GetProductsListWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
            var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Task.FromResult(productsWithCategoryDto);
        }

        public Task<List<ProductWithCategoryDto>> GetProductsListWithCategoryId(int catId)
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey).Where(x=>x.CategoryId==catId);
            var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return Task.FromResult(productsWithCategoryDto);
        }
    }
}
