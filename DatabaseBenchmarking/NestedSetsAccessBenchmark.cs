using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using ParentChildAccess.Data; // Ensure this matches your actual namespace
using ParentChildAccess.Model; // Ensure this matches your actual namespace
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmarking
{
    [MemoryDiagnoser]
    public class NestedSetsAccessBenchmark // Renamed to reflect the focus on Nested Sets
    {
        private ApplicationDbContext _context;

        [GlobalSetup]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);

            // Ensure the database is created and seeded
            await _context.Database.EnsureCreatedAsync();
        }

        [Benchmark]
        public bool CheckAccessBenchmark()
        {
            return _context.Nodes.AsNoTracking().Any(n =>
                _context.Nodes.AsNoTracking().Any(a => a.NodeId == 1 && a.Left < n.Left && a.Right > n.Right) &&
                n.NodeId == 20
            );
        }


    }
}
