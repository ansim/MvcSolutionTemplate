using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Security.Claims;
using $ext_safeprojectname$.Data;

namespace $safeprojectname$
{
    public class IdentityUserStore : Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser, IdentityRole, int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public IdentityUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class IdentityRoleStore : Microsoft.AspNet.Identity.EntityFramework.RoleStore<IdentityRole, int, IdentityUserRole>
    {
        public IdentityRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}