using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace HouseHoldManagementSystem.ABP.EntityFrameworkCore
{
    [DependsOn(
        typeof(ABPCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ABPEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPEntityFrameworkCoreModule).GetAssembly());
        }
    }
}