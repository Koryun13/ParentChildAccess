using Microsoft.EntityFrameworkCore;
using ParentChildAccess.Model;

namespace ParentChildAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeRelation> NodeRelations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Node>().HasData(
                new Node { NodeId = 1, Name = "Node 1" },
                new Node { NodeId = 2, Name = "Node 2" },
                new Node { NodeId = 3, Name = "Node 3" },
                new Node { NodeId = 4, Name = "Node 4" },
                new Node { NodeId = 5, Name = "Node 5" },
                new Node { NodeId = 6, Name = "Node 6" },
                new Node { NodeId = 7, Name = "Node 7" },
                new Node { NodeId = 8, Name = "Node 8" },
                new Node { NodeId = 9, Name = "Node 9" },
                new Node { NodeId = 10, Name = "Node 10" },
                new Node { NodeId = 11, Name = "Node 11" },
                new Node { NodeId = 12, Name = "Node 12" },
                new Node { NodeId = 13, Name = "Node 13" },
                new Node { NodeId = 14, Name = "Node 14" },
                new Node { NodeId = 15, Name = "Node 15" },
                new Node { NodeId = 16, Name = "Node 16" },
                new Node { NodeId = 17, Name = "Node 17" },
                new Node { NodeId = 18, Name = "Node 18" },
                new Node { NodeId = 19, Name = "Node 19" },
                new Node { NodeId = 20, Name = "Node 20" }
            );

            modelBuilder.Entity<NodeRelation>().HasData(
                new NodeRelation { RelationId = 1, ParentNodeId = 1, ChildNodeId = 2 },
                new NodeRelation { RelationId = 2, ParentNodeId = 1, ChildNodeId = 3 },
                new NodeRelation { RelationId = 3, ParentNodeId = 2, ChildNodeId = 4 },
                new NodeRelation { RelationId = 4, ParentNodeId = 2, ChildNodeId = 5 },
                new NodeRelation { RelationId = 5, ParentNodeId = 3, ChildNodeId = 6 },
                new NodeRelation { RelationId = 6, ParentNodeId = 3, ChildNodeId = 7 },
                new NodeRelation { RelationId = 7, ParentNodeId = 4, ChildNodeId = 8 },
                new NodeRelation { RelationId = 8, ParentNodeId = 4, ChildNodeId = 9 },
                new NodeRelation { RelationId = 9, ParentNodeId = 5, ChildNodeId = 10 },
                new NodeRelation { RelationId = 10, ParentNodeId = 5, ChildNodeId = 11 },
                new NodeRelation { RelationId = 11, ParentNodeId = 6, ChildNodeId = 12 },
                new NodeRelation { RelationId = 12, ParentNodeId = 6, ChildNodeId = 13 },
                new NodeRelation { RelationId = 13, ParentNodeId = 7, ChildNodeId = 14 },
                new NodeRelation { RelationId = 14, ParentNodeId = 7, ChildNodeId = 15 },
                new NodeRelation { RelationId = 15, ParentNodeId = 8, ChildNodeId = 16 },
                new NodeRelation { RelationId = 16, ParentNodeId = 8, ChildNodeId = 17 },
                new NodeRelation { RelationId = 17, ParentNodeId = 9, ChildNodeId = 18 },
                new NodeRelation { RelationId = 18, ParentNodeId = 9, ChildNodeId = 19 },
                new NodeRelation { RelationId = 19, ParentNodeId = 10, ChildNodeId = 20 }
            );


            modelBuilder.Entity<NodeRelation>()
                .HasOne(nr => nr.ParentNode)
                .WithMany()
                .HasForeignKey(nr => nr.ParentNodeId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION
        }


    }
}
