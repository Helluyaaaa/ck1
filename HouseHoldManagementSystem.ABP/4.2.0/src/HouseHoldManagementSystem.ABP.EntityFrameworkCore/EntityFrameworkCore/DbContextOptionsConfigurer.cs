using Microsoft.EntityFrameworkCore;

namespace HouseHoldManagementSystem.ABP.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ABPDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ABPDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
