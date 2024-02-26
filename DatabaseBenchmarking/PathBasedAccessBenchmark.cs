using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using ParentChildAccess2.Data;
using ParentChildAccess2.Model; // Ensure this is included if needed for accessing Node entities
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmarking
{
    [MemoryDiagnoser] 
    public class PathBasedAccessBenchmark
    {
        private ApplicationDbContext _context;

        [GlobalSetup]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=NodeDb2;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Benchmark]
        public bool CheckAccessBenchmark()
        {

            // Efficiently fetch only the Path property
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

            return childPath.StartsWith(parentPath);
        }




    }
}
