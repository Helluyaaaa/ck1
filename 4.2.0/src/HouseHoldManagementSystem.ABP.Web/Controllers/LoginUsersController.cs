using HouseHoldManagementSystem.ABP.LoginUser;
using HouseHoldManagementSystem.ABP.LoginUser.Dto;
using HouseHoldManagementSystem.ABP.Web.Models.LoginUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseHoldManagementSystem.ABP.Web.Controllers
{
    public class LoginUsersController:ABPControllerBase
    {
        private readonly ILoginAppService _loginAppService;
        public LoginUsersController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }
        public async Task<IActionResult> Index()
        {
            var loginusers = (await _loginAppService.GetAll(new LoginUserDto())).Items;
            var model = new LoginUserListViewModel
            {
                loginUsers = loginusers
            };

            return View(model);
        }
    }
}
