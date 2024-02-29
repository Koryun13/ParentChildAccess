using AccessTreeGenerator;
using ClosureTableAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ClosureTableAccess.Data;

public class ApplicationDbContext : DbContext
{
    private readonly PerfectBinaryTree treeGenerator = new PerfectBinaryTree();

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

        // Initialize a list to hold Node instances
        
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

        var nodes = new List<Node>();

        // Dynamically generate nodes from 1 to 100
        for (int i = 1; i <= 200; i++)
        {
            // Add a new Node instance to the list with the NodeId and Name set
            nodes.Add(new Node { NodeId = i, Name = $"Node {i}" });
        }

        // Use HasData to seed the generated nodes
        modelBuilder.Entity<Node>().HasData(nodes);

        GenerateAndSeedNodeClosures(modelBuilder);
    }

    private void GenerateAndSeedNodeClosures(ModelBuilder modelBuilder)
    {
        var nodeHierarchy = treeGenerator.GenerateTree(200); // Assuming this generates a perfect binary tree

        var closures = new List<NodeClosure>();

        // Iterate through each node to set up its closure entries
        foreach (var kvp in nodeHierarchy)
        {
            var descendantId = kvp.Key;
            var path = kvp.Value; // The path from the root to this node

            // For each node in the path, create a closure entry
            for (int i = 0; i < path.Count; i++)
            {
                var ancestorId = path[i];
                var depth = path.Count - i - 1; // Depth is calculated based on the position in the path

                closures.Add(new NodeClosure
                {
                    AncestorId = ancestorId,
                    DescendantId = descendantId,
                    Depth = depth
                });
            }
        }

        // Seed the closure entries
        modelBuilder.Entity<NodeClosure>().HasData(closures);
    }

}