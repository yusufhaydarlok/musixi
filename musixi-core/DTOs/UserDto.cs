using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.DTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
