using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ParentChildAccess.Data;

namespace DatabaseBenchmarking
{
    public class DatabaseOperationBenchmark
    {
        private ApplicationDbContext _context;

        [GlobalSetup]
        public void Setup()
        {
            // Configure DbContext to use your actual database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);

            // Optional: Seed the database if necessary
        }

        [Benchmark]
        public void CheckAccessBenchmark()
        {
            // Example: Benchmark a method that checks access
            // Make sure to adjust the method to match what you want to benchmark
            bool hasAccess = _context.NodeRelations.Any(nr => nr.ChildNodeId == 14 && nr.ParentNodeId == 3);
            // Process the result if necessary
        }
    }
}
