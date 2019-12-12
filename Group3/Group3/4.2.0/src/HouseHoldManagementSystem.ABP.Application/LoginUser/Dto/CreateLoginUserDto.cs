using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseHoldManagementSystem.ABP.LoginUser.Dto
{
    public class CreateLoginUserDto
    {
        public const int MaxNameLength = 256;
        public const int MaxPswLength = 256;
        [Required]
        [StringLength(MaxNameLength)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(MaxPswLength)]
        public string Password { get; set; }

        [Required]
        public bool State { get; set; }
    }
}
