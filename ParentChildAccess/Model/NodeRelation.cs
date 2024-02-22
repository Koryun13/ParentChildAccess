using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ParentChildAccess.Model
{
    public class NodeRelation
    {
        [Key]
        public int RelationId { get; set; }

        public int ParentNodeId { get; set; }

        public int ChildNodeId { get; set; }

        [ForeignKey("ParentNodeId")]
        public Node? ParentNode { get; set; }

        [ForeignKey("ChildNodeId")]
        public Node? ChildNode { get; set; }
    }
}
