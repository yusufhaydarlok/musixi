using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using musixi_core.DTOs;
using musixi_core.Models;
using musixi_core.Services;
using musixi_repository;

namespace musixi_api.Controllers
{
    public class AuthenticationController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            // Kullanıcının veritabanında olup olmadığını kontrol edilecek
            var users = await _userService.GetAllAsync();
            var userExist = await users.Any(x => x.Name == );
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new SignResponseDto { Status = "Error", Message = "User already exist!"});
            }

            // Yeni kullanıcı eklenecek
            var user = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }
    }
}
