using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$
{
    //AspNet* tables will be created by OnModelCreating in IdentityDbContext
    //Custom tables will be created by OnModelCreating in ApplicationDbContext


    public class ApplicationUser : IdentityUser<int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationUser()
        {
            IsAuthorized = true;
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
        }


        [Required, StringLength(256)]
        public string DisplayName { get; set; }

        public int UserType { get; set; }

        [DefaultValue(true)]
        public bool IsAuthorized { get; set; }

        public bool IsDeleted { get; set; }

        public int? CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOnDate { get; set; }

        public int? LastModifiedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastModifiedOnDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

    }

    public class IdentityUserRole : IdentityUserRole<int>
    {
    }

    public class IdentityUserClaim : IdentityUserClaim<int> { }

    public class IdentityUserLogin : IdentityUserLogin<int> { }

    public class IdentityRole : IdentityRole<int, IdentityUserRole>
    {
        public IdentityRole() { }

        public IdentityRole(string name)
        {
            Name = name;
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
        }

        [StringLength(50)]
        public string RoleCode { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public int? UserType { get; set; }

        public int? CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOnDate { get; set; }

        public int? LastModifiedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastModifiedOnDate { get; set; }
    }
}
