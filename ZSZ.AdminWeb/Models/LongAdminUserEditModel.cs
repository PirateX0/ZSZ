using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZSZ.AdminWeb.App_Start;

namespace ZSZ.AdminWeb.Models
{
    public class LongAdminUserEditModel
    {
        public long Id { get; set; }

        [Required]
        [ChinaPhone]
        public string PhoneNum { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string Password2 { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public long? CityId { get; set; }
        public long[] RoleIds { get; set; }
    }
}