using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(int userId);
        Task<User> GetUserByAspId(string aspId);
        Task<User> UserLogin(string mail,string password);

    }
}
