using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Models
{
    public class BasketProduct:BaseEntity
    {
        public int BasketId{ get; set; }
        public Basket Basket { get; set; }

        public int ProductId{ get; set; }
        public Product Product { get; set; }
    }
}
