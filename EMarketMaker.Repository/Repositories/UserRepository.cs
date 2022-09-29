using EMarketMaker.Core.Repositories;
using EMarketMaker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMarketMaker.Core.Models;
using Microsoft.EntityFrameworkCore;
using EMarketMaker.Repository.Migrations;

namespace EMarketMaker.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            
        }

        public async Task<User> GetUserByAspId(string aspId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.AspId == aspId);
        }

        public async Task<User> UserLogin(string mail, string password)
        {
            var x44 = await _context.Users.FirstOrDefaultAsync(x => x.Mail == mail && x.Password == password);
            return  x44;
        }
    }
}
