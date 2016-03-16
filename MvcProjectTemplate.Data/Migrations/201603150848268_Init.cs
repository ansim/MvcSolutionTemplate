namespace $safeprojectname$
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                {
                    DeviceID = c.Long(nullable: false, identity: true),
                    Type = c.Short(nullable: false),
                    Name = c.String(nullable: false, maxLength: 500),
                    Status = c.Boolean(nullable: false),
                    CreatedOnDate = c.DateTime(nullable: false),
                    CreatedByUserID = c.Int(),
                    LastModifiedOnDate = c.DateTime(nullable: false),
                    LastModifiedByUserID = c.Int(),
                })
                .PrimaryKey(t => t.DeviceID);

            CreateTable(
              "dbo.Role",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  Name = c.String(nullable: false, maxLength: 256),
                  RoleCode = c.String(nullable: false, maxLength: 50),
                  UserType = c.Int(),
                  Description = c.String(maxLength: 256),
                  CreatedByUserId = c.Int(),
                  CreatedOnDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                  LastModifiedByUserId = c.Int(),
                  LastModifiedOnDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
              })
              .PrimaryKey(t => t.Id)
              .Index(t => t.Name, unique: true, name: "RoleNameIndex")
              .Index(t => t.UserType, unique: false, name: "IX_Role_UserType")
              .Index(t => t.RoleCode, unique: true, name: "IX_Role_RoleCode");

            CreateTable(
                "dbo.UserRole",
                c => new
                {
                    UserId = c.Int(nullable: false),
                    RoleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 256),
                    DisplayName = c.String(nullable: false, maxLength: 256),
                    UserType = c.Int(nullable: false, defaultValue: 0),
                    IsAuthorized = c.Boolean(nullable: false, defaultValue: true),
                    IsDeleted = c.Boolean(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    CreatedByUserId = c.Int(),
                    CreatedOnDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedByUserId = c.Int(),
                    LastModifiedOnDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.UserClaim",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.UserLogin",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Role", new[] { "IX_Role_UserType" });
            DropIndex("dbo.Role", new[] { "IX_Role_RoleCode" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Devices");
        }
    }
}
