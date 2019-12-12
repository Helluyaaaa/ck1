using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace HouseHoldManagementSystem.ABP
{
    [DependsOn(
        typeof(ABPCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ABPApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPApplicationModule).GetAssembly());
        }
    }
}