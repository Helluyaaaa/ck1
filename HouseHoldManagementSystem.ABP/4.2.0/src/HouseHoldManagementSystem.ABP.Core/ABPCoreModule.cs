using Abp.Modules;
using Abp.Reflection.Extensions;
using HouseHoldManagementSystem.ABP.Localization;

namespace HouseHoldManagementSystem.ABP
{
    public class ABPCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ABPLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPCoreModule).GetAssembly());
        }
    }
}