using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'41837a92-248c-4219-9314-e219c9dcf03a', N'admin@vidly.com', N'ADMIN@VIDLY.COM', N'admin@vidly.com', N'ADMIN@VIDLY.COM', 1, N'AQAAAAEAACcQAAAAEMJWWhNwompPqXGkaKmNc8caLmntylneqzh8xrn4y4a20zICHRrQL05XU4xtyvytcA==', N'3J6XO7GAHQ5YLHX744CZDMWO2W5UZXMS', N'285ae106-06a9-40a9-938e-cdbb541f3fbd', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c5c71d00-da43-4d7a-aeac-f8a331e9b7f2', N'guest@vidly.com', N'GUEST@VIDLY.COM', N'guest@vidly.com', N'GUEST@VIDLY.COM', 1, N'AQAAAAEAACcQAAAAEBGjB8jr7moc90rqGlCRNzpV7QKAu2URRfSjPrwyN5ka6vg0uKSpZCEA7SvFgME4qg==', N'2LDOSNDWYX2SX5XWRUF5CPVEUJXFRWKI', N'604cddf1-6c1a-413c-9b40-186c912dfabc', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4e30ad77-b0c9-4878-9c33-94b2ff774ce4', N'CanManageMovies', N'CANMANAGEMOVIES', N'ab816175-f150-4ebe-8a74-87c6871abb98')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'41837a92-248c-4219-9314-e219c9dcf03a', N'4e30ad77-b0c9-4878-9c33-94b2ff774ce4')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
