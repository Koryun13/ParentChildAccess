using Microsoft.EntityFrameworkCore;
using PathBasedAccess.Model;

namespace PathBasedAccess.Data;

public class ApplicationDbContext : DbContext
{
    private readonly Dictionary<int, (int Left, int Right)> nodePositions = new();

    private Dictionary<int, List<int>> nodeHierarchy = new();
    
    public DbSet<Node> Nodes { get; set; }
            
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Initialize nodeHierarchy with existing and dynamically added nodes
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
            var parent = nodeHierarchy.Last().Value.Last(); // Assuming continuation of pattern
            var parentHierarchy = new List<int>(nodeHierarchy[parent]) { i };
            nodeHierarchy.Add(i, parentHierarchy);
        }

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

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Node>().HasData(
//        new Node { NodeId = 1, Name = "Node 1", Path = "1" },
//        new Node { NodeId = 2, Name = "Node 2", Path = "1/2" },
//        new Node { NodeId = 3, Name = "Node 3", Path = "1/3" },
//        new Node { NodeId = 4, Name = "Node 4", Path = "1/2/4" },
//        new Node { NodeId = 5, Name = "Node 5", Path = "1/2/5" },
//        new Node { NodeId = 6, Name = "Node 6", Path = "1/3/6" },
//        new Node { NodeId = 7, Name = "Node 7", Path = "1/3/7" },
//        new Node { NodeId = 8, Name = "Node 8", Path = "1/2/4/8" },
//        new Node { NodeId = 9, Name = "Node 9", Path = "1/2/4/9" },
//        new Node { NodeId = 10, Name = "Node 10", Path = "1/2/5/10" },
//        new Node { NodeId = 11, Name = "Node 11", Path = "1/2/5/11" },
//        new Node { NodeId = 12, Name = "Node 12", Path = "1/3/6/12" },
//        new Node { NodeId = 13, Name = "Node 13", Path = "1/3/6/13" },
//        new Node { NodeId = 14, Name = "Node 14", Path = "1/3/7/14" },
//        new Node { NodeId = 15, Name = "Node 15", Path = "1/3/7/15" },
//        new Node { NodeId = 16, Name = "Node 16", Path = "1/2/4/8/16" },
//        new Node { NodeId = 17, Name = "Node 17", Path = "1/2/4/8/17" },
//        new Node { NodeId = 18, Name = "Node 18", Path = "1/2/4/9/18" },
//        new Node { NodeId = 19, Name = "Node 19", Path = "1/2/4/9/19" },
//        new Node { NodeId = 20, Name = "Node 20", Path = "1/2/5/10/20" }

//        );

//    modelBuilder.Entity<Node>()
//        .HasIndex(n => n.Path)
//        .HasDatabaseName("IDX_Node_Path");

//}

//public async Task AddNodeAsync(int nodeId, int? parentId)
//{
//    Generate the node name based on the NodeId
//    string nodeName = "Node" + nodeId.ToString();

//    Create the new node instance
//   var newNode = new Node { NodeId = nodeId, Name = nodeName };

//    if (parentId.HasValue)
//    {
//        Find the parent node to get its path
//        var parentNode = await Nodes.FindAsync(parentId.Value);
//        if (parentNode == null)
//        {
//            throw new ArgumentException("Parent node not found.", nameof(parentId));
//        }
//        Set the path for the new node based on its parent's path

//       newNode.Path = $"{parentNode.Path}/{newNode.NodeId}";
//    }
//    else
//    {
//        newNode.Path = newNode.NodeId.ToString();
//    }

//    Nodes.Add(newNode);
//    await SaveChangesAsync();
//}