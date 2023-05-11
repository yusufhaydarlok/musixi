using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using musixi_core.DTOs;
using musixi_core.Services;

namespace musixi_api.Controllers
{
    public class RolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            var rolesDto = _mapper.Map<List<RoleDto>>(roles.ToList());
            return CreateActionResult(CustomResponseDto<List<RoleDto>>.Success(200, rolesDto));
        }

        [HttpGet("[action]/{roleId}")]
        public async Task<IActionResult> GetSingleRoleByIdWithUsersAsync(int roleId)
        {
            return CreateActionResult(await _roleService.GetSingleRoleByIdWithUsersAsync(roleId));
        }
    }
}
