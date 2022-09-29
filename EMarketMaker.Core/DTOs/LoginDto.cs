using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.DTOs
{
    public class LoginDto:BaseDto
    {
        public string Mail{ get; set; }
        public string Password{ get; set; }
  
    }
}
