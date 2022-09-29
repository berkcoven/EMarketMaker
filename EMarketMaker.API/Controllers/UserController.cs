using AutoMapper;
using EMarketMaker.Core;
using EMarketMaker.Core.DTOs;
using EMarketMaker.Core.Models;
using EMarketMaker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMarketMaker.API.Controllers
{
    public class UserController : CustomBaseContoller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {

            _userService = userService; 
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users.ToList());
            //return ;
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }
    }
}
