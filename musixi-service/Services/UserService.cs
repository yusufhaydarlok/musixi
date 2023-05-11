using AutoMapper;
using musixi_core.DTOs;
using musixi_core.Models;
using musixi_core.Repositories;
using musixi_core.Services;
using musixi_core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CustomResponseDto<List<UserWithRoleDto>>> GetUsersWithRole()
        {
            var users = await _userRepository.GetUsersWithRole();
            var usersDto = _mapper.Map<List<UserWithRoleDto>>(users);
            return CustomResponseDto<List<UserWithRoleDto>>.Success(200, usersDto);
        }
    }
}
