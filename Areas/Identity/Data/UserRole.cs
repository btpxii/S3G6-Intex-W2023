using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2.Areas.Identity.Data
{
    // Class used to associate users with their roles, utilized by RBAC system
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
