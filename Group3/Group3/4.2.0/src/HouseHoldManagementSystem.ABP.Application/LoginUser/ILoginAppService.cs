using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldManagementSystem.ABP.LoginUser
{
    public interface ILoginAppService: IAsyncCrudAppService<LoginUserDto>
    {
        Task<ListResultDto<LoginUserDto>> GetAllUser(LoginUserDto input);
    }
}
