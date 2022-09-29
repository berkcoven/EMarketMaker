using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.DTOs
{
    public class BasketListDto:BaseEntity
    {
        public Basket Basket{ get; set; }
        public List<ProductDto> ProductList { get; set; }
    }
}
