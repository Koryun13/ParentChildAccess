using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NestedSetsAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDbwithDefValues : Migration
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
                    { 1, 1, "Node 1", 40 },
                    { 2, 2, "Node 2", 15 },
                    { 3, 16, "Node 3", 39 },
                    { 4, 3, "Node 4", 8 },
                    { 5, 9, "Node 5", 14 },
                    { 6, 17, "Node 6", 24 },
                    { 7, 25, "Node 7", 38 },
                    { 8, 4, "Node 8", 5 },
                    { 9, 6, "Node 9", 7 },
                    { 10, 10, "Node 10", 11 },
                    { 11, 12, "Node 11", 13 },
                    { 12, 18, "Node 12", 19 },
                    { 13, 20, "Node 13", 21 },
                    { 14, 26, "Node 14", 27 },
                    { 15, 28, "Node 15", 37 },
                    { 16, 29, "Node 16", 30 },
                    { 17, 31, "Node 17", 32 },
                    { 18, 22, "Node 18", 23 },
                    { 19, 33, "Node 19", 34 },
                    { 20, 35, "Node 20", 36 }
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
