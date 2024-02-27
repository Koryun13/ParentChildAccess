using Microsoft.AspNetCore.Mvc;
using NestedSetsAccess.Data;
using NestedSetsAccess.Model;
using System.Linq;
using System.Threading.Tasks;

namespace NestedSetsAccess.Controllers
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

        [HttpPost]
        public async Task<ActionResult<Node>> CreateNode(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNode), new { id = node.NodeId }, node);
        }


        [HttpGet("{nodeId}/access/{parentId}")]
        public ActionResult<bool> CheckAccess(int nodeId, int parentId)
        {
            // In Nested Sets, check if a node is a descendant by comparing Left and Right values
            var parentNode = _context.Nodes.Find(parentId);
            var childNode = _context.Nodes.Find(nodeId);

            if (parentNode == null || childNode == null)
            {
                return NotFound("One or both of the nodes not found.");
            }

            bool hasAccess = childNode.Left > parentNode.Left && childNode.Right < parentNode.Right;
            return hasAccess;
        }

    }
}
