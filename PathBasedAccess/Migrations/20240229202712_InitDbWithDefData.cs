﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PathBasedAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDbWithDefData : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    { 20, "Node 20", "1/2/5/10/20" },
                    { 21, "Node 21", "1/2/5/10/21" },
                    { 22, "Node 22", "1/2/5/11/22" },
                    { 23, "Node 23", "1/2/5/11/23" },
                    { 24, "Node 24", "1/3/6/12/24" },
                    { 25, "Node 25", "1/3/6/12/25" },
                    { 26, "Node 26", "1/3/6/13/26" },
                    { 27, "Node 27", "1/3/6/13/27" },
                    { 28, "Node 28", "1/3/7/14/28" },
                    { 29, "Node 29", "1/3/7/14/29" },
                    { 30, "Node 30", "1/3/7/15/30" },
                    { 31, "Node 31", "1/3/7/15/31" },
                    { 32, "Node 32", "1/2/4/8/16/32" },
                    { 33, "Node 33", "1/2/4/8/16/33" },
                    { 34, "Node 34", "1/2/4/8/17/34" },
                    { 35, "Node 35", "1/2/4/8/17/35" },
                    { 36, "Node 36", "1/2/4/9/18/36" },
                    { 37, "Node 37", "1/2/4/9/18/37" },
                    { 38, "Node 38", "1/2/4/9/19/38" },
                    { 39, "Node 39", "1/2/4/9/19/39" },
                    { 40, "Node 40", "1/2/5/10/20/40" },
                    { 41, "Node 41", "1/2/5/10/20/41" },
                    { 42, "Node 42", "1/2/5/10/21/42" },
                    { 43, "Node 43", "1/2/5/10/21/43" },
                    { 44, "Node 44", "1/2/5/11/22/44" },
                    { 45, "Node 45", "1/2/5/11/22/45" },
                    { 46, "Node 46", "1/2/5/11/23/46" },
                    { 47, "Node 47", "1/2/5/11/23/47" },
                    { 48, "Node 48", "1/3/6/12/24/48" },
                    { 49, "Node 49", "1/3/6/12/24/49" },
                    { 50, "Node 50", "1/3/6/12/25/50" },
                    { 51, "Node 51", "1/3/6/12/25/51" },
                    { 52, "Node 52", "1/3/6/13/26/52" },
                    { 53, "Node 53", "1/3/6/13/26/53" },
                    { 54, "Node 54", "1/3/6/13/27/54" },
                    { 55, "Node 55", "1/3/6/13/27/55" },
                    { 56, "Node 56", "1/3/7/14/28/56" },
                    { 57, "Node 57", "1/3/7/14/28/57" },
                    { 58, "Node 58", "1/3/7/14/29/58" },
                    { 59, "Node 59", "1/3/7/14/29/59" },
                    { 60, "Node 60", "1/3/7/15/30/60" },
                    { 61, "Node 61", "1/3/7/15/30/61" },
                    { 62, "Node 62", "1/3/7/15/31/62" },
                    { 63, "Node 63", "1/3/7/15/31/63" },
                    { 64, "Node 64", "1/2/4/8/16/32/64" },
                    { 65, "Node 65", "1/2/4/8/16/32/65" },
                    { 66, "Node 66", "1/2/4/8/16/33/66" },
                    { 67, "Node 67", "1/2/4/8/16/33/67" },
                    { 68, "Node 68", "1/2/4/8/17/34/68" },
                    { 69, "Node 69", "1/2/4/8/17/34/69" },
                    { 70, "Node 70", "1/2/4/8/17/35/70" },
                    { 71, "Node 71", "1/2/4/8/17/35/71" },
                    { 72, "Node 72", "1/2/4/9/18/36/72" },
                    { 73, "Node 73", "1/2/4/9/18/36/73" },
                    { 74, "Node 74", "1/2/4/9/18/37/74" },
                    { 75, "Node 75", "1/2/4/9/18/37/75" },
                    { 76, "Node 76", "1/2/4/9/19/38/76" },
                    { 77, "Node 77", "1/2/4/9/19/38/77" },
                    { 78, "Node 78", "1/2/4/9/19/39/78" },
                    { 79, "Node 79", "1/2/4/9/19/39/79" },
                    { 80, "Node 80", "1/2/5/10/20/40/80" },
                    { 81, "Node 81", "1/2/5/10/20/40/81" },
                    { 82, "Node 82", "1/2/5/10/20/41/82" },
                    { 83, "Node 83", "1/2/5/10/20/41/83" },
                    { 84, "Node 84", "1/2/5/10/21/42/84" },
                    { 85, "Node 85", "1/2/5/10/21/42/85" },
                    { 86, "Node 86", "1/2/5/10/21/43/86" },
                    { 87, "Node 87", "1/2/5/10/21/43/87" },
                    { 88, "Node 88", "1/2/5/11/22/44/88" },
                    { 89, "Node 89", "1/2/5/11/22/44/89" },
                    { 90, "Node 90", "1/2/5/11/22/45/90" },
                    { 91, "Node 91", "1/2/5/11/22/45/91" },
                    { 92, "Node 92", "1/2/5/11/23/46/92" },
                    { 93, "Node 93", "1/2/5/11/23/46/93" },
                    { 94, "Node 94", "1/2/5/11/23/47/94" },
                    { 95, "Node 95", "1/2/5/11/23/47/95" },
                    { 96, "Node 96", "1/3/6/12/24/48/96" },
                    { 97, "Node 97", "1/3/6/12/24/48/97" },
                    { 98, "Node 98", "1/3/6/12/24/49/98" },
                    { 99, "Node 99", "1/3/6/12/24/49/99" },
                    { 100, "Node 100", "1/3/6/12/25/50/100" },
                    { 101, "Node 101", "1/3/6/12/25/50/101" },
                    { 102, "Node 102", "1/3/6/12/25/51/102" },
                    { 103, "Node 103", "1/3/6/12/25/51/103" },
                    { 104, "Node 104", "1/3/6/13/26/52/104" },
                    { 105, "Node 105", "1/3/6/13/26/52/105" },
                    { 106, "Node 106", "1/3/6/13/26/53/106" },
                    { 107, "Node 107", "1/3/6/13/26/53/107" },
                    { 108, "Node 108", "1/3/6/13/27/54/108" },
                    { 109, "Node 109", "1/3/6/13/27/54/109" },
                    { 110, "Node 110", "1/3/6/13/27/55/110" },
                    { 111, "Node 111", "1/3/6/13/27/55/111" },
                    { 112, "Node 112", "1/3/7/14/28/56/112" },
                    { 113, "Node 113", "1/3/7/14/28/56/113" },
                    { 114, "Node 114", "1/3/7/14/28/57/114" },
                    { 115, "Node 115", "1/3/7/14/28/57/115" },
                    { 116, "Node 116", "1/3/7/14/29/58/116" },
                    { 117, "Node 117", "1/3/7/14/29/58/117" },
                    { 118, "Node 118", "1/3/7/14/29/59/118" },
                    { 119, "Node 119", "1/3/7/14/29/59/119" },
                    { 120, "Node 120", "1/3/7/15/30/60/120" },
                    { 121, "Node 121", "1/3/7/15/30/60/121" },
                    { 122, "Node 122", "1/3/7/15/30/61/122" },
                    { 123, "Node 123", "1/3/7/15/30/61/123" },
                    { 124, "Node 124", "1/3/7/15/31/62/124" },
                    { 125, "Node 125", "1/3/7/15/31/62/125" },
                    { 126, "Node 126", "1/3/7/15/31/63/126" },
                    { 127, "Node 127", "1/3/7/15/31/63/127" },
                    { 128, "Node 128", "1/2/4/8/16/32/64/128" },
                    { 129, "Node 129", "1/2/4/8/16/32/64/129" },
                    { 130, "Node 130", "1/2/4/8/16/32/65/130" },
                    { 131, "Node 131", "1/2/4/8/16/32/65/131" },
                    { 132, "Node 132", "1/2/4/8/16/33/66/132" },
                    { 133, "Node 133", "1/2/4/8/16/33/66/133" },
                    { 134, "Node 134", "1/2/4/8/16/33/67/134" },
                    { 135, "Node 135", "1/2/4/8/16/33/67/135" },
                    { 136, "Node 136", "1/2/4/8/17/34/68/136" },
                    { 137, "Node 137", "1/2/4/8/17/34/68/137" },
                    { 138, "Node 138", "1/2/4/8/17/34/69/138" },
                    { 139, "Node 139", "1/2/4/8/17/34/69/139" },
                    { 140, "Node 140", "1/2/4/8/17/35/70/140" },
                    { 141, "Node 141", "1/2/4/8/17/35/70/141" },
                    { 142, "Node 142", "1/2/4/8/17/35/71/142" },
                    { 143, "Node 143", "1/2/4/8/17/35/71/143" },
                    { 144, "Node 144", "1/2/4/9/18/36/72/144" },
                    { 145, "Node 145", "1/2/4/9/18/36/72/145" },
                    { 146, "Node 146", "1/2/4/9/18/36/73/146" },
                    { 147, "Node 147", "1/2/4/9/18/36/73/147" },
                    { 148, "Node 148", "1/2/4/9/18/37/74/148" },
                    { 149, "Node 149", "1/2/4/9/18/37/74/149" },
                    { 150, "Node 150", "1/2/4/9/18/37/75/150" },
                    { 151, "Node 151", "1/2/4/9/18/37/75/151" },
                    { 152, "Node 152", "1/2/4/9/19/38/76/152" },
                    { 153, "Node 153", "1/2/4/9/19/38/76/153" },
                    { 154, "Node 154", "1/2/4/9/19/38/77/154" },
                    { 155, "Node 155", "1/2/4/9/19/38/77/155" },
                    { 156, "Node 156", "1/2/4/9/19/39/78/156" },
                    { 157, "Node 157", "1/2/4/9/19/39/78/157" },
                    { 158, "Node 158", "1/2/4/9/19/39/79/158" },
                    { 159, "Node 159", "1/2/4/9/19/39/79/159" },
                    { 160, "Node 160", "1/2/5/10/20/40/80/160" },
                    { 161, "Node 161", "1/2/5/10/20/40/80/161" },
                    { 162, "Node 162", "1/2/5/10/20/40/81/162" },
                    { 163, "Node 163", "1/2/5/10/20/40/81/163" },
                    { 164, "Node 164", "1/2/5/10/20/41/82/164" },
                    { 165, "Node 165", "1/2/5/10/20/41/82/165" },
                    { 166, "Node 166", "1/2/5/10/20/41/83/166" },
                    { 167, "Node 167", "1/2/5/10/20/41/83/167" },
                    { 168, "Node 168", "1/2/5/10/21/42/84/168" },
                    { 169, "Node 169", "1/2/5/10/21/42/84/169" },
                    { 170, "Node 170", "1/2/5/10/21/42/85/170" },
                    { 171, "Node 171", "1/2/5/10/21/42/85/171" },
                    { 172, "Node 172", "1/2/5/10/21/43/86/172" },
                    { 173, "Node 173", "1/2/5/10/21/43/86/173" },
                    { 174, "Node 174", "1/2/5/10/21/43/87/174" },
                    { 175, "Node 175", "1/2/5/10/21/43/87/175" },
                    { 176, "Node 176", "1/2/5/11/22/44/88/176" },
                    { 177, "Node 177", "1/2/5/11/22/44/88/177" },
                    { 178, "Node 178", "1/2/5/11/22/44/89/178" },
                    { 179, "Node 179", "1/2/5/11/22/44/89/179" },
                    { 180, "Node 180", "1/2/5/11/22/45/90/180" },
                    { 181, "Node 181", "1/2/5/11/22/45/90/181" },
                    { 182, "Node 182", "1/2/5/11/22/45/91/182" },
                    { 183, "Node 183", "1/2/5/11/22/45/91/183" },
                    { 184, "Node 184", "1/2/5/11/23/46/92/184" },
                    { 185, "Node 185", "1/2/5/11/23/46/92/185" },
                    { 186, "Node 186", "1/2/5/11/23/46/93/186" },
                    { 187, "Node 187", "1/2/5/11/23/46/93/187" },
                    { 188, "Node 188", "1/2/5/11/23/47/94/188" },
                    { 189, "Node 189", "1/2/5/11/23/47/94/189" },
                    { 190, "Node 190", "1/2/5/11/23/47/95/190" },
                    { 191, "Node 191", "1/2/5/11/23/47/95/191" },
                    { 192, "Node 192", "1/3/6/12/24/48/96/192" },
                    { 193, "Node 193", "1/3/6/12/24/48/96/193" },
                    { 194, "Node 194", "1/3/6/12/24/48/97/194" },
                    { 195, "Node 195", "1/3/6/12/24/48/97/195" },
                    { 196, "Node 196", "1/3/6/12/24/49/98/196" },
                    { 197, "Node 197", "1/3/6/12/24/49/98/197" },
                    { 198, "Node 198", "1/3/6/12/24/49/99/198" },
                    { 199, "Node 199", "1/3/6/12/24/49/99/199" },
                    { 200, "Node 200", "1/3/6/12/25/50/100/200" }
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Node_Path",
                table: "Nodes",
                column: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
