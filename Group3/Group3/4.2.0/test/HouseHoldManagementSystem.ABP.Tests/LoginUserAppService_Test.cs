using HouseHoldManagementSystem.ABP.LoginUser;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HouseHoldManagementSystem.ABP.Tests
{
    public class LoginUserAppService_Test:ABPTestBase
    {
        public ILoginAppService _loginAppService;
        public LoginUserAppService_Test()
        {
            _loginAppService = Resolve<ILoginAppService>();
        }
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Tasks()
        {
            //Act
            var output = await _loginAppService.GetAllUser(new LoginUser.Dto.LoginUserDto());

            //Assert
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Filtered_Tasks()
        {
            //Act
            var output = await _loginAppService.GetAllUser(new LoginUser.Dto.LoginUserDto { State = true });

            //Assert
            output.Items.ShouldAllBe(t => t.State == true);
        }
    }
}
