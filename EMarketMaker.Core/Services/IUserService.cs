using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Services
{
    public interface IUserService: IService<User>
    {
        Task<UserDto> GetUserDtoWithAspId(string aspId);
    }
}
