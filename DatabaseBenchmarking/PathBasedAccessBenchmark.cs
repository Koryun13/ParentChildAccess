using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PathBasedAccess.Data;

namespace DatabaseBenchmarking
{
    [MemoryDiagnoser] 
    public class PathBasedAccessBenchmark
    {
        private ApplicationDbContext? _context;

        [GlobalSetup]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb2;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);

            await _context.Database.EnsureCreatedAsync();

        }

        [Benchmark]
        public bool PathBasedBenchmark()
        {

            // Efficiently fetch only the Path property
            if (_context != null)
            {
                string? childPath = _context.Nodes
                    .AsNoTracking()
                    .Where(n => n.NodeId == 20)
                    .Select(n => n.Path)
                    .FirstOrDefault();

                string? parentPath = _context.Nodes
                    .AsNoTracking()
                    .Where(n => n.NodeId == 1)
                    .Select(n => n.Path)
                    .FirstOrDefault();

                return childPath != null && parentPath != null && childPath.StartsWith(parentPath);
            }
            return false;
        }




    }
}
