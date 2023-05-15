using musixi_core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_core.Services
{
    public interface ISignInService
    {
        Task<UserDto> Login(string username, string password);
    }
}
