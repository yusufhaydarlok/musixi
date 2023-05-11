using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.DTOs
{
    public class RoleWithUsersDto : RoleDto
    {
        public List<UserDto> Users { get; set; }
    }
}
