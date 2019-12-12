using Abp.AspNetCore.Mvc.Controllers;

namespace HouseHoldManagementSystem.ABP.Web.Controllers
{
    public abstract class ABPControllerBase: AbpController
    {
        protected ABPControllerBase()
        {
            LocalizationSourceName = ABPConsts.LocalizationSourceName;
        }
    }
}