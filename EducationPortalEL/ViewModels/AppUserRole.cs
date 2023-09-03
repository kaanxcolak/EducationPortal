using EducationPortalEL.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortalEL.ViewModels
{
    public class AppUserRole
    {
        public AppUser User { get; set; }
        public AppRole? Role { get; set; }
        public string RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
