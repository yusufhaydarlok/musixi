using AutoMapper;
using musixi_core.DTOs;
using musixi_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserWithRoleDto>();
            CreateMap<Role, RoleWithUsersDto>();
        }
    }
}
