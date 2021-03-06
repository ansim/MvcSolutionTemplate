// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace $safeprojectname$
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IApplicationDbContext
    {
        public System.Data.Entity.DbSet<Device> Devices { get; set; } // Devices
        
        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, DbMigrationConfiguration>());
        }

		public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public ApplicationDbContext()
            : base("Name=DefaultConnection")
        {
        }

        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }

        public ApplicationDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ApplicationUser>().ToTable("User");
			modelBuilder.Entity<IdentityRole>().ToTable("Role");
			modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
			modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
			modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Configurations.Add(new DeviceConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new DeviceConfiguration(schema));
            return modelBuilder;
        }
    }
}
// </auto-generated>
