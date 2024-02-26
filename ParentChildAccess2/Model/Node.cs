using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParentChildAccess2.Model
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }

        public string? Name { get; set; }
    }

    
}
