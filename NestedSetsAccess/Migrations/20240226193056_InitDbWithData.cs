using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NestedSetsAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDbWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Left = table.Column<int>(type: "int", nullable: false),
                    Right = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "Left", "Name", "Right" },
                values: new object[,]
                {
                    { 1, 1, "Node 1", 2 },
                    { 2, 3, "Node 2", 6 },
                    { 3, 7, "Node 3", 10 },
                    { 4, 11, "Node 4", 16 },
                    { 5, 17, "Node 5", 22 },
                    { 6, 23, "Node 6", 28 },
                    { 7, 29, "Node 7", 34 },
                    { 8, 35, "Node 8", 42 },
                    { 9, 43, "Node 9", 50 },
                    { 10, 51, "Node 10", 58 },
                    { 11, 59, "Node 11", 66 },
                    { 12, 67, "Node 12", 74 },
                    { 13, 75, "Node 13", 82 },
                    { 14, 83, "Node 14", 90 },
                    { 15, 91, "Node 15", 98 },
                    { 16, 99, "Node 16", 108 },
                    { 17, 109, "Node 17", 118 },
                    { 18, 119, "Node 18", 128 },
                    { 19, 129, "Node 19", 138 },
                    { 20, 139, "Node 20", 148 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
