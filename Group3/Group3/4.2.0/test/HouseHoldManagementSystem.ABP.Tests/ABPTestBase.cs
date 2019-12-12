using System;
using System.Threading.Tasks;
using Abp.TestBase;
using HouseHoldManagementSystem.ABP.EntityFrameworkCore;
using HouseHoldManagementSystem.ABP.Tests.TestDatas;

namespace HouseHoldManagementSystem.ABP.Tests
{
    public class ABPTestBase : AbpIntegratedTestBase<ABPTestModule>
    {
        public ABPTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ABPDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ABPDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ABPDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ABPDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ABPDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ABPDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ABPDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ABPDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
