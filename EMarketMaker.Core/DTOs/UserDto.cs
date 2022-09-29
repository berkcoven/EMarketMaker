using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.DTOs
{
    public class UserDto:BaseDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
      
    }
}
