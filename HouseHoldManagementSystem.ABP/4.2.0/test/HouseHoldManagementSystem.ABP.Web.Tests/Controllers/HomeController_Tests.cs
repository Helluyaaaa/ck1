using System.Threading.Tasks;
using HouseHoldManagementSystem.ABP.Web.Controllers;
using Shouldly;
using Xunit;

namespace HouseHoldManagementSystem.ABP.Web.Tests.Controllers
{
    public class HomeController_Tests: ABPWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
