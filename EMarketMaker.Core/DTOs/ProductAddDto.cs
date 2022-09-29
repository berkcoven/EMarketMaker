using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.DTOs
{
    public class ProductAddDto
    {
        public ProductDto ProductDto { get; set; }
        public List<CategoryDto> categoryDtos { get; set; }
    }
}
