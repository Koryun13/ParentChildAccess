namespace AccessTreeGenerator
{
    using System;
    using System.Collections.Generic;

    public class PerfectBinaryTree
    {
        private int totalNodes;
        private Dictionary<int, List<int>> nodeHierarchy;

        public PerfectBinaryTree()
        {
            this.nodeHierarchy = new Dictionary<int, List<int>>();
        }

        public Dictionary<int, List<int>> GenerateTree(int totalNodes)
        {
            this.totalNodes = totalNodes;

            // Only proceed if there are nodes to generate
            if (totalNodes > 0)
            {
                // Initialize the tree with the root node
                AddNode(1, new List<int>());
            }

            return this.nodeHierarchy;
        }

        private void AddNode(int nodeId, List<int> parentPath)
        {
            // Stop adding nodes if we've reached the total node count
            if (nodeId > this.totalNodes) return;

            // Create a new path for the current node by extending the parent's path
            var newPath = new List<int>(parentPath) { nodeId };
            this.nodeHierarchy[nodeId] = newPath;

            int leftChildId = nodeId * 2;
            int rightChildId = nodeId * 2 + 1;

            // Add left child if possible
            if (leftChildId <= this.totalNodes)
            {
                AddNode(leftChildId, newPath);
            }

            // Add right child if possible
            if (rightChildId <= this.totalNodes)
            {
                AddNode(rightChildId, newPath);
            }
        }
    }
}