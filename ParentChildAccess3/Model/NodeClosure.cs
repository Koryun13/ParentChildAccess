
namespace ParentChildAccess3.Model
{
    public class NodeClosure
    {
        public int AncestorId { get; set; }
        public int DescendantId { get; set; }
        public int Depth { get; set; }

        public Node Ancestor { get; set; }
        public Node Descendant { get; set; }
    }
}
