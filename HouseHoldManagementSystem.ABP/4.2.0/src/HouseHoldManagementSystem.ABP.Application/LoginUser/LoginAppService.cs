using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldManagementSystem.ABP.LoginUser
{
    public class LoginAppService : AbpServiceBase, ILoginAppService
    {
        private readonly IRepository<LoginUser> _loginuserRepository;
        public LoginAppService(IRepository<LoginUser> loginuserRepository)
        {
            _loginuserRepository = loginuserRepository;
        }
        public async Task<ListResultDto<LoginUserDto>> GetAll(LoginUserDto input)
        {
            var loginusers = await _loginuserRepository
                .GetAll()
                .WhereIf(input.State, t => t.State == input.State)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            return new ListResultDto<LoginUserDto>(
                ObjectMapper.Map<List<LoginUserDto>>(loginusers)
            );
        }
    }
}
