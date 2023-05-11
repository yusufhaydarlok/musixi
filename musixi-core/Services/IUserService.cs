using musixi_core.DTOs;
using musixi_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<List<UserWithRoleDto>>> GetUsersWithRole();
    }
}
