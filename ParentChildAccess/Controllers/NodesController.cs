using Microsoft.AspNetCore.Mvc;
using ParentChildAccess.Data;
using ParentChildAccess.Model;
using System.Linq;

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
        public ActionResult<Node> CreateNode(Node node)
        {
            _context.Nodes.Add(node);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetNode), new { id = node.NodeId }, node);
        }

        [HttpPost("{parentId}/children")]
        public ActionResult<NodeRelation> AddChild(int parentId, NodeRelation relation)
        {
            var parentNode = _context.Nodes.Find(parentId);
            if (parentNode == null)
            {
                return NotFound();
            }

            relation.ParentNode = parentNode;
            _context.NodeRelations.Add(relation);
            _context.SaveChanges();
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
