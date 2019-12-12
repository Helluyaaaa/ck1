using Abp.Application.Services;

namespace HouseHoldManagementSystem.ABP
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ABPAppServiceBase : ApplicationService
    {
        protected ABPAppServiceBase()
        {
            LocalizationSourceName = ABPConsts.LocalizationSourceName;
        }
    }
}