using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using PathBasedAccess.Data;
using PathBasedAccess.Model;

namespace ParentChildAccess.Controllers
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
        public async Task<ActionResult<bool>> CheckAccess(int nodeId, int parentId)
        {
            var childNode = await _context.Nodes.FindAsync(nodeId);
            var parentNode = await _context.Nodes.FindAsync(parentId);

            if (childNode == null || parentNode == null)
            {
                return NotFound("One or both of the nodes not found.");
            }

            // Check if the child's path starts with the parent's path
            bool hasAccess = childNode.Path.StartsWith(parentNode.Path);
            return hasAccess;
        }

        private bool NodeExists(int id)
        {
            return _context.Nodes.Any(e => e.NodeId == id);
        }
    }
}
