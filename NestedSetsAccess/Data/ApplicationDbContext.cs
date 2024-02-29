using AccessTreeGenerator;
using Microsoft.EntityFrameworkCore;
using NestedSetsAccess.Model;

namespace NestedSetsAccess.Data;

public class ApplicationDbContext : DbContext
{
    private readonly Dictionary<int, (int Left, int Right)> nodePositions = new();
    private Dictionary<int, List<int>> nodeHierarchy;
    private readonly PerfectBinaryTree treeGenerator = new();


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Node> Nodes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Node>().Property(n => n.NodeId).HasColumnOrder(1);
        modelBuilder.Entity<Node>().Property(n => n.Name).HasColumnOrder(2);
        modelBuilder.Entity<Node>().Property(n => n.Left).HasColumnOrder(3);
        modelBuilder.Entity<Node>().Property(n => n.Right).HasColumnOrder(4);


        SeedNodesWithNestedSets(modelBuilder);
    }

    private void SeedNodesWithNestedSets(ModelBuilder modelBuilder)
    {
        nodeHierarchy = treeGenerator.GenerateTree(200);

        CalculateNestedSets(1, 1); // Assuming 1 is the root node

        // Seed the nodes with the calculated nested set values
        foreach (var position in nodePositions)
            modelBuilder.Entity<Node>().HasData(new Node
            {
                NodeId = position.Key,
                Name = $"Node {position.Key}",
                Left = position.Value.Left,
                Right = position.Value.Right
            });
    }
    
    private int CalculateNestedSets(int nodeId, int counter)
    {
        var left = counter++;
        var children = FindDirectChildren(nodeId);

        foreach (var childId in children) counter = CalculateNestedSets(childId, counter) + 1;

        var right = counter;
        nodePositions[nodeId] = (left, right);
        return right;
    }

    private List<int> FindDirectChildren(int nodeId)
    {
        return nodeHierarchy
            .Where(kvp => kvp.Value.Contains(nodeId) && kvp.Value.Count == nodeHierarchy[nodeId].Count + 1 &&
                          kvp.Value[nodeHierarchy[nodeId].Count - 1] == nodeId)
            .Select(kvp => kvp.Key)
            .ToList();
    }
}