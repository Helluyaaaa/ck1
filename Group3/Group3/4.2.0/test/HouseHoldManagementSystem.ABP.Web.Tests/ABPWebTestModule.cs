using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HouseHoldManagementSystem.ABP.Web.Startup;
namespace HouseHoldManagementSystem.ABP.Web.Tests
{
    [DependsOn(
        typeof(ABPWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ABPWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPWebTestModule).GetAssembly());
        }
    }
}