using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldManagementSystem.ABP.EntityFrameworkCore
{
    public class ABPDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public ABPDbContext(DbContextOptions<ABPDbContext> options) 
            : base(options)
        {

        }
        public DbSet<LoginUser.LoginUser> LoginUsers { get; set; }
    }
}
