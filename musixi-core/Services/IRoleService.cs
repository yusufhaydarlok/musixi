using musixi_core.DTOs;
using musixi_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.Services
{
    public interface IRoleService : IService<Role>
    {
        Task<CustomResponseDto<RoleWithUsersDto>> GetSingleRoleByIdWithUsersAsync(int roleId);
    }
}
