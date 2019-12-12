using HouseHoldManagementSystem.ABP.Configuration;
using HouseHoldManagementSystem.ABP.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HouseHoldManagementSystem.ABP.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class ABPDbContextFactory : IDesignTimeDbContextFactory<ABPDbContext>
    {
        public ABPDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ABPDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ABPConsts.ConnectionStringName)
            );

            return new ABPDbContext(builder.Options);
        }
    }
}