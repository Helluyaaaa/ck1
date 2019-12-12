using Abp.AspNetCore.Mvc.Views;

namespace HouseHoldManagementSystem.ABP.Web.Views
{
    public abstract class ABPRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ABPRazorPage()
        {
            LocalizationSourceName = ABPConsts.LocalizationSourceName;
        }
    }
}
