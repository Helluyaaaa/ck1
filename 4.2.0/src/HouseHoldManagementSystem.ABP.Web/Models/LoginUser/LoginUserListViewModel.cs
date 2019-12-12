using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseHoldManagementSystem.ABP.Web.Models.LoginUser
{
    public class LoginUserListViewModel
    {
        public IReadOnlyList<LoginUserDto> loginUsers { get; set; }
    }
}
