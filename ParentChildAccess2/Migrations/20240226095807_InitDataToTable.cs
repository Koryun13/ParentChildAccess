using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParentChildAccess2.Migrations
{
    /// <inheritdoc />
    public partial class InitDataToTable : Migration
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
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "Name", "Path" },
                values: new object[,]
                {
                    { 1, "Node 1", "1" },
                    { 2, "Node 2", "1/2" },
                    { 3, "Node 3", "1/3" },
                    { 4, "Node 4", "1/2/4" },
                    { 5, "Node 5", "1/2/5" },
                    { 6, "Node 6", "1/3/6" },
                    { 7, "Node 7", "1/3/7" },
                    { 8, "Node 8", "1/2/4/8" },
                    { 9, "Node 9", "1/2/4/9" },
                    { 10, "Node 10", "1/2/5/10" },
                    { 11, "Node 11", "1/2/5/11" },
                    { 12, "Node 12", "1/3/6/12" },
                    { 13, "Node 13", "1/3/6/13" },
                    { 14, "Node 14", "1/3/7/14" },
                    { 15, "Node 15", "1/3/7/15" },
                    { 16, "Node 16", "1/2/4/8/16" },
                    { 17, "Node 17", "1/2/4/8/17" },
                    { 18, "Node 18", "1/2/4/9/18" },
                    { 19, "Node 19", "1/2/4/9/19" },
                    { 20, "Node 20", "1/2/5/10/20" }
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
