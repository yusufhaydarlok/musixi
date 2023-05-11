using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using musixi_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musixi_repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            new User { Id = 1, RoleId = 1, Name = "Yusuf Haydar", Password = "elmasoldum", CreatedDate = DateTime.Now },
            new User { Id = 2, RoleId = 2, Name = "Ahmet Can Kılıç", Password = "karabüyüsura", CreatedDate = DateTime.Now },
            new User { Id = 3, RoleId = 2, Name = "Gürkan Özer", Password = "cekare", CreatedDate = DateTime.Now }
            );
        }
    }
}
