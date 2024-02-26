using Microsoft.EntityFrameworkCore;
using ParentChildAccess3.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace ParentChildAccess3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeClosure> NodeClosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Node entity
            modelBuilder.Entity<Node>()
                .HasKey(n => n.NodeId);

            modelBuilder.Entity<Node>()
                .Property(n => n.Name)
                .IsRequired();

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
            // NodeClosure entity
            modelBuilder.Entity<NodeClosure>()
                .HasKey(nc => new { nc.AncestorId, nc.DescendantId });

            modelBuilder.Entity<NodeClosure>()
                .HasOne(nc => nc.Ancestor)
                .WithMany()
                .HasForeignKey(nc => nc.AncestorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NodeClosure>()
                .HasOne(nc => nc.Descendant)
                .WithMany()
                .HasForeignKey(nc => nc.DescendantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NodeClosure>()
                .Property(nc => nc.Depth)
                .IsRequired();

            // Optional: Configure indexes for faster lookup
            modelBuilder.Entity<NodeClosure>()
                .HasIndex(nc => nc.AncestorId);

            modelBuilder.Entity<NodeClosure>()
                .HasIndex(nc => nc.DescendantId);

            GenerateAndSeedNodeClosures(modelBuilder);
        }

        private void GenerateAndSeedNodeClosures(ModelBuilder modelBuilder)
        {

            Dictionary<int, List<int>> nodeHierarchy = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{ 1 } },
                { 2, new List<int>{ 1, 2 } },
                { 3, new List<int>{ 1, 3 } },
                { 4, new List<int>{ 1, 2, 4 } },
                { 5, new List<int>{ 1, 2, 5 } },
                { 6, new List<int>{ 1, 3, 6 } },
                { 7, new List<int>{ 1, 3, 7 } },
                { 8, new List<int>{ 1, 2, 4, 8 } },
                { 9, new List<int>{ 1, 2, 4, 9 } },
                { 10, new List<int>{ 1, 2, 5, 10 } },
                { 11, new List<int>{ 1, 2, 5, 11 } },
                { 12, new List<int>{ 1, 3, 6, 12 } },
                { 13, new List<int>{ 1, 3, 6, 13 } },
                { 14, new List<int>{ 1, 3, 7, 14 } },
                { 15, new List<int>{ 1, 3, 7, 15 } },
                { 16, new List<int>{ 1, 2, 4, 8, 16 } },
                { 17, new List<int>{ 1, 2, 4, 8, 17 } },
                { 18, new List<int>{ 1, 2, 4, 9, 18 } },
                { 19, new List<int>{ 1, 2, 4, 9, 19 } },
                { 20, new List<int>{ 1, 2, 5, 10, 20 } }
            };

            var closures = new List<NodeClosure>();

            foreach (var kvp in nodeHierarchy)
            {
                int descendantId = kvp.Key;
                var ancestors = kvp.Value;

                foreach (var ancestorId in ancestors)
                {
                    int depth = ancestors.IndexOf(descendantId) - ancestors.IndexOf(ancestorId);
                    closures.Add(new NodeClosure
                    {
                        AncestorId = ancestorId,
                        DescendantId = descendantId,
                        Depth = depth
                    });
                }
            }

            // Assuming NodeClosure has an Id property that's auto-generated. If not, you might need to manage Ids manually.
            foreach (var closure in closures)
            {
                modelBuilder.Entity<NodeClosure>().HasData(closure);
            }
        }
    }
}
