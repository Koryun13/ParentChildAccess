using Microsoft.EntityFrameworkCore;
using NestedSetsAccess.Model;

namespace NestedSetsAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedNodesWithNestedSets(modelBuilder);
        }

        private void SeedNodesWithNestedSets(ModelBuilder modelBuilder)
        {

            Dictionary<int, (int Left, int Right)> nodePositions = new Dictionary<int, (int, int)> //This data is equivalent to tree data used in other access methods
            {
                { 1, (1, 40) },
                { 2, (2, 15) },
                { 3, (16, 39) },
                { 4, (3, 8) },
                { 5, (9, 14) },
                { 6, (17, 24) },
                { 7, (25, 38) },
                { 8, (4, 5) },
                { 9, (6, 7) },
                { 10, (10, 11) },
                { 11, (12, 13) },
                { 12, (18, 19) },
                { 13, (20, 21) },
                { 14, (26, 27) },
                { 15, (28, 37) },
                { 16, (29, 30) },
                { 17, (31, 32) },
                { 18, (22, 23) },
                { 19, (33, 34) },
                { 20, (35, 36) }
            };


            foreach (var position in nodePositions)
            {
                modelBuilder.Entity<Node>().HasData(new Node
                {
                    NodeId = position.Key,
                    Name = $"Node {position.Key}",
                    Left = position.Value.Left,
                    Right = position.Value.Right
                });
            }
        }
    }
}


















//using Microsoft.EntityFrameworkCore;
//using NestedSetsAccess.Model;

//namespace NestedSetsAccess.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
//        }

//        public DbSet<Node> Nodes { get; set; }
//        public DbSet<NodeRelation> NodeRelations { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {



//            modelBuilder.Entity<Node>().HasData(
//                new Node { NodeId = 1, Name = "Node 1" },
//                new Node { NodeId = 2, Name = "Node 2" },
//                new Node { NodeId = 3, Name = "Node 3" },
//                new Node { NodeId = 4, Name = "Node 4" },
//                new Node { NodeId = 5, Name = "Node 5" },
//                new Node { NodeId = 6, Name = "Node 6" },
//                new Node { NodeId = 7, Name = "Node 7" },
//                new Node { NodeId = 8, Name = "Node 8" },
//                new Node { NodeId = 9, Name = "Node 9" },
//                new Node { NodeId = 10, Name = "Node 10" },
//                new Node { NodeId = 11, Name = "Node 11" },
//                new Node { NodeId = 12, Name = "Node 12" },
//                new Node { NodeId = 13, Name = "Node 13" },
//                new Node { NodeId = 14, Name = "Node 14" },
//                new Node { NodeId = 15, Name = "Node 15" },
//                new Node { NodeId = 16, Name = "Node 16" },
//                new Node { NodeId = 17, Name = "Node 17" },
//                new Node { NodeId = 18, Name = "Node 18" },
//                new Node { NodeId = 19, Name = "Node 19" },
//                new Node { NodeId = 20, Name = "Node 20" }
//            );

//            modelBuilder.Entity<NodeRelation>().HasData(
//                new NodeRelation { RelationId = 1, ParentNodeId = 1, ChildNodeId = 2 },
//                new NodeRelation { RelationId = 2, ParentNodeId = 1, ChildNodeId = 3 },
//                new NodeRelation { RelationId = 3, ParentNodeId = 2, ChildNodeId = 4 },
//                new NodeRelation { RelationId = 4, ParentNodeId = 2, ChildNodeId = 5 },
//                new NodeRelation { RelationId = 5, ParentNodeId = 3, ChildNodeId = 6 },
//                new NodeRelation { RelationId = 6, ParentNodeId = 3, ChildNodeId = 7 },
//                new NodeRelation { RelationId = 7, ParentNodeId = 4, ChildNodeId = 8 },
//                new NodeRelation { RelationId = 8, ParentNodeId = 4, ChildNodeId = 9 },
//                new NodeRelation { RelationId = 9, ParentNodeId = 5, ChildNodeId = 10 },
//                new NodeRelation { RelationId = 10, ParentNodeId = 5, ChildNodeId = 11 },
//                new NodeRelation { RelationId = 11, ParentNodeId = 6, ChildNodeId = 12 },
//                new NodeRelation { RelationId = 12, ParentNodeId = 6, ChildNodeId = 13 },
//                new NodeRelation { RelationId = 13, ParentNodeId = 7, ChildNodeId = 14 },
//                new NodeRelation { RelationId = 14, ParentNodeId = 7, ChildNodeId = 15 },
//                new NodeRelation { RelationId = 15, ParentNodeId = 8, ChildNodeId = 16 },
//                new NodeRelation { RelationId = 16, ParentNodeId = 8, ChildNodeId = 17 },
//                new NodeRelation { RelationId = 17, ParentNodeId = 9, ChildNodeId = 18 },
//                new NodeRelation { RelationId = 18, ParentNodeId = 9, ChildNodeId = 19 },
//                new NodeRelation { RelationId = 19, ParentNodeId = 10, ChildNodeId = 20 },
//                // Indirect relationships
//                new NodeRelation { RelationId = 20, ParentNodeId = 1, ChildNodeId = 4 },
//                new NodeRelation { RelationId = 21, ParentNodeId = 1, ChildNodeId = 5 },
//                new NodeRelation { RelationId = 22, ParentNodeId = 1, ChildNodeId = 6 },
//                new NodeRelation { RelationId = 23, ParentNodeId = 1, ChildNodeId = 7 },
//                new NodeRelation { RelationId = 24, ParentNodeId = 1, ChildNodeId = 8 },
//                new NodeRelation { RelationId = 25, ParentNodeId = 1, ChildNodeId = 9 },
//                new NodeRelation { RelationId = 26, ParentNodeId = 1, ChildNodeId = 10 },
//                new NodeRelation { RelationId = 27, ParentNodeId = 1, ChildNodeId = 11 },
//                new NodeRelation { RelationId = 28, ParentNodeId = 2, ChildNodeId = 6 },
//                new NodeRelation { RelationId = 29, ParentNodeId = 2, ChildNodeId = 7 },
//                new NodeRelation { RelationId = 30, ParentNodeId = 2, ChildNodeId = 8 },
//                new NodeRelation { RelationId = 31, ParentNodeId = 2, ChildNodeId = 9 },
//                new NodeRelation { RelationId = 32, ParentNodeId = 2, ChildNodeId = 10 },
//                new NodeRelation { RelationId = 33, ParentNodeId = 2, ChildNodeId = 11 },
//                new NodeRelation { RelationId = 34, ParentNodeId = 3, ChildNodeId = 8 },
//                new NodeRelation { RelationId = 35, ParentNodeId = 3, ChildNodeId = 9 },
//                new NodeRelation { RelationId = 36, ParentNodeId = 3, ChildNodeId = 10 },
//                new NodeRelation { RelationId = 37, ParentNodeId = 3, ChildNodeId = 11 },
//                new NodeRelation { RelationId = 38, ParentNodeId = 3, ChildNodeId = 12 },
//                new NodeRelation { RelationId = 39, ParentNodeId = 3, ChildNodeId = 13 },
//                new NodeRelation { RelationId = 40, ParentNodeId = 3, ChildNodeId = 14 },
//                new NodeRelation { RelationId = 41, ParentNodeId = 3, ChildNodeId = 15 },
//                new NodeRelation { RelationId = 42, ParentNodeId = 4, ChildNodeId = 10 },
//                new NodeRelation { RelationId = 43, ParentNodeId = 4, ChildNodeId = 11 },
//                new NodeRelation { RelationId = 44, ParentNodeId = 4, ChildNodeId = 12 },
//                new NodeRelation { RelationId = 45, ParentNodeId = 4, ChildNodeId = 13 },
//                new NodeRelation { RelationId = 46, ParentNodeId = 4, ChildNodeId = 14 },
//                new NodeRelation { RelationId = 47, ParentNodeId = 4, ChildNodeId = 15 },
//                new NodeRelation { RelationId = 48, ParentNodeId = 4, ChildNodeId = 16 },
//                new NodeRelation { RelationId = 49, ParentNodeId = 4, ChildNodeId = 17 },
//                new NodeRelation { RelationId = 50, ParentNodeId = 5, ChildNodeId = 12 },
//                new NodeRelation { RelationId = 51, ParentNodeId = 5, ChildNodeId = 13 },
//                new NodeRelation { RelationId = 52, ParentNodeId = 5, ChildNodeId = 14 },
//                new NodeRelation { RelationId = 53, ParentNodeId = 5, ChildNodeId = 15 },
//                new NodeRelation { RelationId = 54, ParentNodeId = 5, ChildNodeId = 16 },
//                new NodeRelation { RelationId = 55, ParentNodeId = 5, ChildNodeId = 17 },
//                new NodeRelation { RelationId = 56, ParentNodeId = 5, ChildNodeId = 18 },
//                new NodeRelation { RelationId = 57, ParentNodeId = 5, ChildNodeId = 19 },
//                new NodeRelation { RelationId = 58, ParentNodeId = 6, ChildNodeId = 14 },
//                new NodeRelation { RelationId = 59, ParentNodeId = 6, ChildNodeId = 15 },
//                new NodeRelation { RelationId = 60, ParentNodeId = 6, ChildNodeId = 16 },
//                new NodeRelation { RelationId = 61, ParentNodeId = 6, ChildNodeId = 17 },
//                new NodeRelation { RelationId = 62, ParentNodeId = 6, ChildNodeId = 18 },
//                new NodeRelation { RelationId = 63, ParentNodeId = 6, ChildNodeId = 19 },
//                new NodeRelation { RelationId = 64, ParentNodeId = 6, ChildNodeId = 20 },
//                new NodeRelation { RelationId = 65, ParentNodeId = 7, ChildNodeId = 16 },
//                new NodeRelation { RelationId = 66, ParentNodeId = 7, ChildNodeId = 17 },
//                new NodeRelation { RelationId = 67, ParentNodeId = 7, ChildNodeId = 18 },
//                new NodeRelation { RelationId = 68, ParentNodeId = 7, ChildNodeId = 19 },
//                new NodeRelation { RelationId = 69, ParentNodeId = 7, ChildNodeId = 20 },
//                new NodeRelation { RelationId = 70, ParentNodeId = 8, ChildNodeId = 18 },
//                new NodeRelation { RelationId = 71, ParentNodeId = 8, ChildNodeId = 19 },
//                new NodeRelation { RelationId = 72, ParentNodeId = 8, ChildNodeId = 20 },
//                new NodeRelation { RelationId = 73, ParentNodeId = 9, ChildNodeId = 20 }

//              );


//            modelBuilder.Entity<NodeRelation>()
//                .HasOne(nr => nr.ParentNode)
//                .WithMany()
//                .HasForeignKey(nr => nr.ParentNodeId)
//                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION


//        }

//        public async Task AddNodeRelationAsync(int parentId, int childId)
//        {
//            // Add the direct relationship
//            var directRelation = new NodeRelation { ParentNodeId = parentId, ChildNodeId = childId };
//            NodeRelations.Add(directRelation);

//            // Find all ancestors of the parent and add indirect relations
//            var ancestors = GetAllAncestors(parentId);
//            foreach (var ancestor in ancestors)
//            {
//                var indirectRelation = new NodeRelation { ParentNodeId = ancestor.NodeId, ChildNodeId = childId };
//                NodeRelations.Add(indirectRelation);
//            }

//            await SaveChangesAsync();
//        }

//        // Helper method to get all ancestors of a given node
//        private List<Node> GetAllAncestors(int nodeId)
//        {
//            var ancestors = new List<Node>();
//            var currentParentId = NodeRelations.AsNoTracking().FirstOrDefault(nr => nr.ChildNodeId == nodeId)?.ParentNodeId;

//            while (currentParentId.HasValue)
//            {
//                var parentNode = Nodes.AsNoTracking().FirstOrDefault(n => n.NodeId == currentParentId.Value);
//                if (parentNode != null)
//                {
//                    ancestors.Add(parentNode);
//                    currentParentId = NodeRelations.AsNoTracking().FirstOrDefault(nr => nr.ChildNodeId == parentNode.NodeId)?.ParentNodeId;
//                }
//                else
//                {
//                    break;
//                }
//            }

//            return ancestors;
//        }


//    }
//}
