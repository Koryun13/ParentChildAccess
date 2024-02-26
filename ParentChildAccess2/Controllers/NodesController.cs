using Microsoft.AspNetCore.Mvc;
using ParentChildAccess2.Data;
using ParentChildAccess2.Model;
using System.Linq;
using System.Threading.Tasks; // Added for async support

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

        [HttpPost]
        public async Task<ActionResult<Node>> CreateNode(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNode), new { id = node.NodeId }, node);
        }

        [HttpPost("{parentId}/children")]
        public async Task<ActionResult<NodeRelation>> AddChild(int parentId, NodeRelation relation)
        {
            var parentNode = _context.Nodes.Find(parentId);
            if (parentNode == null)
            {
                return NotFound();
            }

            // Use the new AddNodeRelationAsync method
            await _context.AddNodeRelationAsync(parentId, relation.ChildNodeId);

            // Since AddNodeRelationAsync handles adding the relation, no need to add again
            // Just return the result
            return CreatedAtAction(nameof(GetNode), new { id = relation.ChildNodeId }, relation);
        }

        [HttpGet("{nodeId}/access/{parentId}")]
        public ActionResult<bool> CheckAccess(int nodeId, int parentId)
        {
            var relation = _context.NodeRelations.FirstOrDefault(r => r.ChildNodeId == nodeId && r.ParentNodeId == parentId);
            return relation != null;
        }

        private bool NodeExists(int id)
        {
            return _context.Nodes.Any(e => e.NodeId == id);
        }
    }
}
