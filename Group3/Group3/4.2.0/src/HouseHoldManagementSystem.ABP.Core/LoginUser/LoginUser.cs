using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace HouseHoldManagementSystem.ABP.LoginUser
{
    [Table("AppLoginUser")]
    public class LoginUser: Entity
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
