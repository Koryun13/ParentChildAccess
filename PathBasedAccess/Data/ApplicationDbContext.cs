using AccessTreeGenerator;
using Microsoft.EntityFrameworkCore;
using PathBasedAccess.Model;

namespace PathBasedAccess.Data;

public class ApplicationDbContext : DbContext
{
    private readonly Dictionary<int, (int Left, int Right)> nodePositions = new();

    private Dictionary<int, List<int>> nodeHierarchy = new();

    private readonly PerfectBinaryTree treeGenerator = new();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Node> Nodes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Initialize nodeHierarchy with existing and dynamically added nodes
        nodeHierarchy = treeGenerator.GenerateTree(200);

        // Generate Node instances based on nodeHierarchy for seeding
        var nodes = nodeHierarchy.Select(kvp =>
        {
            var path = string.Join("/", kvp.Value); // Create path string
            return new Node { NodeId = kvp.Key, Name = $"Node {kvp.Key}", Path = path };
        }).ToList();

        // Seed the nodes
        modelBuilder.Entity<Node>().HasData(nodes);

        modelBuilder.Entity<Node>()
            .HasIndex(n => n.Path)
            .HasDatabaseName("IDX_Node_Path");
    }
}