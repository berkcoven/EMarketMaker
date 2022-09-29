using EMarketMaker.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Models
{
    public class Basket:BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public int userId { get; set; }
       
    }
}
