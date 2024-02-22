using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParentChildAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitTableData : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { 19, 20, 10 }
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
