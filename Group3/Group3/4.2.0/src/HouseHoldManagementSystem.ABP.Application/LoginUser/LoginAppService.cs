using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldManagementSystem.ABP.LoginUser
{
    public class LoginAppService : AsyncCrudAppService<LoginUser,LoginUserDto>, ILoginAppService
    {
        private readonly IRepository<LoginUser> _loginuserRepository;
        public LoginAppService(IRepository<LoginUser> loginuserRepository):base(loginuserRepository)
        {
            _loginuserRepository = loginuserRepository;
        }
        public async Task<ListResultDto<LoginUserDto>> GetAllUser(LoginUserDto input)
        {
            var loginusers = await _loginuserRepository
                .GetAll()
                .Where(t => t.State == true)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            return new ListResultDto<LoginUserDto>(
                ObjectMapper.Map<List<LoginUserDto>>(loginusers)
            );
        }
        public async Task<LoginUser> CreateNew(LoginUserDto input)
        {
            var newloginuser = new LoginUser()
            {
                Id = input.Id,
                Password = input.Password,
                LoginName = input.LoginName,
                State = true
            };
            return await _loginuserRepository.InsertAsync(newloginuser);
        }
        public override async Task Delete(EntityDto<int> input)
        {
             _loginuserRepository.Get(input.Id).State = false;
            await _loginuserRepository
                .GetAll()
                .Where(t => t.State == true)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            /*var loginusers = await _loginuserRepository
                .GetAll()
                .Where(t => t.State == true)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            new ListResultDto<LoginUserDto>(
                ObjectMapper.Map<List<LoginUserDto>>(loginusers)
            );*/
        }
    }
}
