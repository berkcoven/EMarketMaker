using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Repositories;
using EMarketMaker.Core.Services;
using EMarketMaker.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _productRepository = productRepository; 
            _mapper = mapper;   
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
           var product = await _productRepository.GetProductsWithCategory();
            var productDtos =_mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productDtos);
        }
        public async Task<List<ProductWithCategoryDto>> GetProductsListWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();
            var productDtos = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return productDtos;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsListWithCategoryId(int catId)
        {
            var product = await _productRepository.GetProductsWithCategoryId(catId);
            var productDtos = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return productDtos;
        }
    }
}
