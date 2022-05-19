using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class UpdateNameForMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.UpdateData(
            //    table: "MembershipTypes",
            //    keyColumn: "Id",
            //    keyValue: "1",
            //    column: "Name",
            //    value: "Pay As You Go");
            
            //migrationBuilder.UpdateData(
            //    table: "MembershipTypes",
            //    keyColumn: "Id",
            //    keyValue: "2",
            //    column: "Name",
            //    value: "Monthly");

            //migrationBuilder.UpdateData(
            //    table: "MembershipTypes",
            //    keyColumn: "Id",
            //    keyValue: "1",
            //    column: "Name",
            //    value: "Quarterly");

            //migrationBuilder.UpdateData(
            //    table: "MembershipTypes",
            //    keyColumn: "Id",
            //    keyValue: "1",
            //    column: "Name",
            //    value: "Annually");

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValues: new[] {"1", "2", "3", "4"},
                column: "Name",
                values: new[] { "Pay As You Go", "Monthly", "Quarterly", "Annually"});

            //migrationBuilder.Sql(
            //    "UPDATE MembershipTypes" +
            //    "SET Name = CASE WHEN Id = 1 THEN 'Pay As You Go'" +
            //    "                WHEN Id = 2 THEN 'Monthly'" +
            //    "                WHEN Id = 3 THEN 'Quarterly'" +
            //    "                WHEN Id = 4 THEN 'Annually'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
