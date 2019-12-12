using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldManagementSystem.ABP.LoginUser
{
    public interface ILoginAppService:IApplicationService
    {
        Task<ListResultDto<LoginUserDto>> GetAll(LoginUserDto input);
    }
}
