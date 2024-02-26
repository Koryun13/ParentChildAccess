using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParentChildAccess3.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "NodeClosures",
                columns: table => new
                {
                    AncestorId = table.Column<int>(type: "int", nullable: false),
                    DescendantId = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeClosures", x => new { x.AncestorId, x.DescendantId });
                    table.ForeignKey(
                        name: "FK_NodeClosures_Nodes_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NodeClosures_Nodes_DescendantId",
                        column: x => x.DescendantId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Restrict);
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
                table: "NodeClosures",
                columns: new[] { "AncestorId", "DescendantId", "Depth" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 1 },
                    { 1, 3, 1 },
                    { 1, 4, 2 },
                    { 1, 5, 2 },
                    { 1, 6, 2 },
                    { 1, 7, 2 },
                    { 1, 8, 3 },
                    { 1, 9, 3 },
                    { 1, 10, 3 },
                    { 1, 11, 3 },
                    { 1, 12, 3 },
                    { 1, 13, 3 },
                    { 1, 14, 3 },
                    { 1, 15, 3 },
                    { 1, 16, 4 },
                    { 1, 17, 4 },
                    { 1, 18, 4 },
                    { 1, 19, 4 },
                    { 1, 20, 4 },
                    { 2, 2, 0 },
                    { 2, 4, 1 },
                    { 2, 5, 1 },
                    { 2, 8, 2 },
                    { 2, 9, 2 },
                    { 2, 10, 2 },
                    { 2, 11, 2 },
                    { 2, 16, 3 },
                    { 2, 17, 3 },
                    { 2, 18, 3 },
                    { 2, 19, 3 },
                    { 2, 20, 3 },
                    { 3, 3, 0 },
                    { 3, 6, 1 },
                    { 3, 7, 1 },
                    { 3, 12, 2 },
                    { 3, 13, 2 },
                    { 3, 14, 2 },
                    { 3, 15, 2 },
                    { 4, 4, 0 },
                    { 4, 8, 1 },
                    { 4, 9, 1 },
                    { 4, 16, 2 },
                    { 4, 17, 2 },
                    { 4, 18, 2 },
                    { 4, 19, 2 },
                    { 5, 5, 0 },
                    { 5, 10, 1 },
                    { 5, 11, 1 },
                    { 5, 20, 2 },
                    { 6, 6, 0 },
                    { 6, 12, 1 },
                    { 6, 13, 1 },
                    { 7, 7, 0 },
                    { 7, 14, 1 },
                    { 7, 15, 1 },
                    { 8, 8, 0 },
                    { 8, 16, 1 },
                    { 8, 17, 1 },
                    { 9, 9, 0 },
                    { 9, 18, 1 },
                    { 9, 19, 1 },
                    { 10, 10, 0 },
                    { 10, 20, 1 },
                    { 11, 11, 0 },
                    { 12, 12, 0 },
                    { 13, 13, 0 },
                    { 14, 14, 0 },
                    { 15, 15, 0 },
                    { 16, 16, 0 },
                    { 17, 17, 0 },
                    { 18, 18, 0 },
                    { 19, 19, 0 },
                    { 20, 20, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeClosures_AncestorId",
                table: "NodeClosures",
                column: "AncestorId");

            migrationBuilder.CreateIndex(
                name: "IX_NodeClosures_DescendantId",
                table: "NodeClosures",
                column: "DescendantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeClosures");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
