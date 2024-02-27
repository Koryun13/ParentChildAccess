using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using NestedSetsAccess.Data;

namespace DatabaseBenchmarking
{
    [MemoryDiagnoser]
    public class NestedSetsAccessBenchmark 
    {
        private ApplicationDbContext? _context;

        [GlobalSetup]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);

            await _context.Database.EnsureCreatedAsync();
        }

        [Benchmark]
        public bool NestedSetsBenchmark()
        {
            return _context != null && _context.Nodes.AsNoTracking().Any(n =>
                _context.Nodes.AsNoTracking().Any(a => a.NodeId == 1 && a.Left < n.Left && a.Right > n.Right) &&
                n.NodeId == 20
            );
        }


    }
}
