using Microsoft.EntityFrameworkCore;
using musixi_core.Models;
using musixi_core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetUsersWithRole()
        {
            return await _context.Users.Include(x => x.Role).ToListAsync();
        }
    }
}
