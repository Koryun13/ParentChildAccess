using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ClosureTableAccess.Data;
using ClosureTableAccess.Model;

namespace ClosureTableAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Node> GetNode(int id)
        {
            var node = _context.Nodes.Find(id);
            if (node == null)
            {
                return NotFound();
            }
            return node;
        }


        [HttpGet("{nodeId}/access/{parentId}")]
        public ActionResult<bool> CheckAccess(int nodeId, int parentId)
        {
            // Check if an entry exists in the NodeClosure table with the given ancestor and descendant
            var hasAccess = _context.NodeClosures.Any(nc => nc.AncestorId == parentId && nc.DescendantId == nodeId);
            return hasAccess;
        }

        private bool NodeExists(int id)
        {
            return _context.Nodes.Any(e => e.NodeId == id);
        }
    }
}
