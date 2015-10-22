using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Model
{
    public class Node
    {
        public int Id { get; private set; }

        public string Label { get; private set; }

        public List<int> AdjacentIds { get; set; }

        public List<Node> AdjacentNodes { get; set; }

        public Node(int id, string label)
        {
            Id = id;
            Label = label; 
            AdjacentIds = new List<int>();
            AdjacentNodes = new List<Node>();
        }

        public Node(int id, string label, IEnumerable<int> adjacentIds)
            : this(id, label)
        {
            AdjacentIds.AddRange(adjacentIds);

        }
        public Node(int id, string label, IEnumerable<Node> adjacentNodes)
            :this(id, label)
        {          
            AdjacentNodes.AddRange(adjacentNodes);
        }
    }
}
