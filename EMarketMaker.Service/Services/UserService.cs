using EMarketMaker.Core.Services;
using EMarketMaker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMarketMaker.Core.Models;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Repositories;
using EMarketMaker.Core.UnitOfWorks;
using AutoMapper;
using EMarketMaker.Core.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using EMarketMaker.Repository.Repositories;

namespace EMarketMaker.Service.Services
{
    public class UserService : Service<User>, IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(IGenericRepository<User> repository, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper= mapper;
            _appSettings = appSettings.Value;

        }

        public async Task<UserDto> GetUserDtoWithAspId(string aspId)
        {
            var user = await _userRepository.GetUserByAspId(aspId);
            var userDto= _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
