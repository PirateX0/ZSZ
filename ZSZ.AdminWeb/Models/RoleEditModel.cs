using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZSZ.AdminWeb.Models
{
    public class RoleEditModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long[] PermissionIds { get; set; }
    }
}