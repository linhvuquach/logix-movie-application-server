using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logix_Movie_Application.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisLiked",
                table: "UserActivities");

            migrationBuilder.DropColumn(
                name: "MoviewId",
                table: "UserActivities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisLiked",
                table: "UserActivities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MoviewId",
                table: "UserActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
