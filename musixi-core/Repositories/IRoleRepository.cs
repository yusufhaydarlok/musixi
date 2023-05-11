using musixi_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetSingleRoleByIdWithUsersAsync(int roleİd);
    }
}
