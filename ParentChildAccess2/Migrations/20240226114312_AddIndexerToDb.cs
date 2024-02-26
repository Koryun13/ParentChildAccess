using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentChildAccess2.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexerToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Nodes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IDX_Node_Path",
                table: "Nodes",
                column: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDX_Node_Path",
                table: "Nodes");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
