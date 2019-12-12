using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseHoldManagementSystem.ABP.LoginUser.Dto
{
    [AutoMap(typeof(LoginUser))]
    public class LoginUserDto:EntityDto
    {
        public const int MaxNameLength = 256;
        public const int MaxPswLength = 256;
        [StringLength(MaxNameLength)]
        public string LoginName { get; set; }
        [StringLength(MaxPswLength)]
        public string Password { get; set; }
        public bool State { get; set; }
    }
}
