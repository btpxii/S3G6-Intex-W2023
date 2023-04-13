using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intex2.Areas.Identity.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string AdminRoleId = Guid.NewGuid().ToString();
        private string ResearcherRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO ""AspNetRoles"" (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql($@"INSERT INTO ""AspNetRoles"" (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
            VALUES ('{ResearcherRoleId}', 'Researcher', 'RESEARCHER', null);");
            migrationBuilder.Sql($@"INSERT INTO ""AspNetRoles"" (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
