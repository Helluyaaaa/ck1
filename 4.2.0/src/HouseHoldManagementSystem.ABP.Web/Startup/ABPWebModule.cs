using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HouseHoldManagementSystem.ABP.Configuration;
using HouseHoldManagementSystem.ABP.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HouseHoldManagementSystem.ABP.Web.Startup
{
    [DependsOn(
        typeof(ABPApplicationModule), 
        typeof(ABPEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ABPWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ABPWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ABPConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ABPNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ABPApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPWebModule).GetAssembly());
        }
    }
}