using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ClosureTableAccess.Data;

namespace DatabaseBenchmarking
{
    [MemoryDiagnoser]
    public class ClosureTableAccessBenchmark
    {
        private ApplicationDbContext? _context;

        [GlobalSetup]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb3;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);

            // Ensure the database is created and seeded
            await _context.Database.EnsureCreatedAsync();
        }

        [Benchmark]
        public bool ClosureTableBenchmark()
        {
            // Query the NodeClosure table to check for access between two nodes
            bool hasAccess = _context != null && _context.NodeClosures
                .AsNoTracking()
                .Any(nc => nc.AncestorId == 1 && nc.DescendantId == 200); // Example ancestor and descendant

            return hasAccess;
        }
    }
}
