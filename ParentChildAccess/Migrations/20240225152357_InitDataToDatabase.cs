using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParentChildAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDataToDatabase : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "NodeRelations",
                columns: table => new
                {
                    RelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentNodeId = table.Column<int>(type: "int", nullable: false),
                    ChildNodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeRelations", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_NodeRelations_Nodes_ChildNodeId",
                        column: x => x.ChildNodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NodeRelations_Nodes_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId");
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "Name" },
                values: new object[,]
                {
                    { 1, "Node 1" },
                    { 2, "Node 2" },
                    { 3, "Node 3" },
                    { 4, "Node 4" },
                    { 5, "Node 5" },
                    { 6, "Node 6" },
                    { 7, "Node 7" },
                    { 8, "Node 8" },
                    { 9, "Node 9" },
                    { 10, "Node 10" },
                    { 11, "Node 11" },
                    { 12, "Node 12" },
                    { 13, "Node 13" },
                    { 14, "Node 14" },
                    { 15, "Node 15" },
                    { 16, "Node 16" },
                    { 17, "Node 17" },
                    { 18, "Node 18" },
                    { 19, "Node 19" },
                    { 20, "Node 20" }
                });

            migrationBuilder.InsertData(
                table: "NodeRelations",
                columns: new[] { "RelationId", "ChildNodeId", "ParentNodeId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 2 },
                    { 4, 5, 2 },
                    { 5, 6, 3 },
                    { 6, 7, 3 },
                    { 7, 8, 4 },
                    { 8, 9, 4 },
                    { 9, 10, 5 },
                    { 10, 11, 5 },
                    { 11, 12, 6 },
                    { 12, 13, 6 },
                    { 13, 14, 7 },
                    { 14, 15, 7 },
                    { 15, 16, 8 },
                    { 16, 17, 8 },
                    { 17, 18, 9 },
                    { 18, 19, 9 },
                    { 19, 20, 10 },
                    { 20, 4, 1 },
                    { 21, 5, 1 },
                    { 22, 6, 1 },
                    { 23, 7, 1 },
                    { 24, 8, 1 },
                    { 25, 9, 1 },
                    { 26, 10, 1 },
                    { 27, 11, 1 },
                    { 28, 6, 2 },
                    { 29, 7, 2 },
                    { 30, 8, 2 },
                    { 31, 9, 2 },
                    { 32, 10, 2 },
                    { 33, 11, 2 },
                    { 34, 8, 3 },
                    { 35, 9, 3 },
                    { 36, 10, 3 },
                    { 37, 11, 3 },
                    { 38, 12, 3 },
                    { 39, 13, 3 },
                    { 40, 14, 3 },
                    { 41, 15, 3 },
                    { 42, 10, 4 },
                    { 43, 11, 4 },
                    { 44, 12, 4 },
                    { 45, 13, 4 },
                    { 46, 14, 4 },
                    { 47, 15, 4 },
                    { 48, 16, 4 },
                    { 49, 17, 4 },
                    { 50, 12, 5 },
                    { 51, 13, 5 },
                    { 52, 14, 5 },
                    { 53, 15, 5 },
                    { 54, 16, 5 },
                    { 55, 17, 5 },
                    { 56, 18, 5 },
                    { 57, 19, 5 },
                    { 58, 14, 6 },
                    { 59, 15, 6 },
                    { 60, 16, 6 },
                    { 61, 17, 6 },
                    { 62, 18, 6 },
                    { 63, 19, 6 },
                    { 64, 20, 6 },
                    { 65, 16, 7 },
                    { 66, 17, 7 },
                    { 67, 18, 7 },
                    { 68, 19, 7 },
                    { 69, 20, 7 },
                    { 70, 18, 8 },
                    { 71, 19, 8 },
                    { 72, 20, 8 },
                    { 73, 20, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeRelations_ChildNodeId",
                table: "NodeRelations",
                column: "ChildNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeRelations_ParentNodeId",
                table: "NodeRelations",
                column: "ParentNodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeRelations");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
