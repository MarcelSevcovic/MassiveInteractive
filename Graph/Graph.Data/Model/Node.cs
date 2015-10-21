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

        public List<Node> AdjacentNodes { get; set; }

        public Node(int id, string label)
        {
            Id = id;
            Label = label;
            
        }
        public Node(int id, string label, List<Node> adjacentNodes):this(id, label)
        {          
            AdjacentNodes = adjacentNodes;
        }
    }
}
