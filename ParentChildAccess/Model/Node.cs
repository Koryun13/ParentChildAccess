namespace NestedSetsAccess.Model
{
    public class Node
    {
        public int NodeId { get; set; }

        public string Name { get; set; }
        
        public int Left { get; set; }  // 'Left' value in the Nested Sets model
       
        public int Right { get; set; } // 'Right' value in the Nested Sets model
    }
}
