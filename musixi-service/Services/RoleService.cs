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
    public class RoleService : Service<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IGenericRepository<Role> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<CustomResponseDto<RoleWithUsersDto>> GetSingleRoleByIdWithUsersAsync(int roleId)
        {
            var role = await _roleRepository.GetSingleRoleByIdWithUsersAsync(roleId);
            var roleDto = _mapper.Map<RoleWithUsersDto>(role);
            return CustomResponseDto<RoleWithUsersDto>.Success(200, roleDto);
        }
    }
}
