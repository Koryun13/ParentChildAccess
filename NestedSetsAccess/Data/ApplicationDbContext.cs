using Microsoft.EntityFrameworkCore;
using NestedSetsAccess.Model;

namespace NestedSetsAccess.Data;

public class ApplicationDbContext : DbContext
{
    private readonly Dictionary<int, (int Left, int Right)> nodePositions = new();
    private Dictionary<int, List<int>> nodeHierarchy = new();

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
        InitializeNodeHierarchy();

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

    private void InitializeNodeHierarchy()
    {
        // Pre-populated nodeHierarchy for demonstration, plus dynamic extension to node 100
        nodeHierarchy = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 1 } },
            { 2, new List<int> { 1, 2 } },
            { 3, new List<int> { 1, 3 } },
            { 4, new List<int> { 1, 2, 4 } },
            { 5, new List<int> { 1, 2, 5 } },
            { 6, new List<int> { 1, 3, 6 } },
            { 7, new List<int> { 1, 3, 7 } },
            { 8, new List<int> { 1, 2, 4, 8 } },
            { 9, new List<int> { 1, 2, 4, 9 } },
            { 10, new List<int> { 1, 2, 5, 10 } },
            { 11, new List<int> { 1, 2, 5, 11 } },
            { 12, new List<int> { 1, 3, 6, 12 } },
            { 13, new List<int> { 1, 3, 6, 13 } },
            { 14, new List<int> { 1, 3, 7, 14 } },
            { 15, new List<int> { 1, 3, 7, 15 } },
            { 16, new List<int> { 1, 2, 4, 8, 16 } },
            { 17, new List<int> { 1, 2, 4, 8, 17 } },
            { 18, new List<int> { 1, 2, 4, 9, 18 } },
            { 19, new List<int> { 1, 2, 4, 9, 19 } },
            { 20, new List<int> { 1, 2, 5, 10, 20 } }
        };

        for (var i = 21; i <= 100; i++)
        {
            var parent = nodeHierarchy.Last().Value.Last(); // Simplified assumption for parent
            var parentHierarchy = new List<int>(nodeHierarchy[parent]) { i };
            nodeHierarchy.Add(i, parentHierarchy);
        }
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