using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Model
{
    public abstract class GraphBase
    {
        public List<Node> Nodes { get; private set; }

        protected GraphBase(IEnumerable<Node> nodes)
        {
            Nodes = new List<Node>();
            Nodes.AddRange(nodes);
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public abstract void AddRelation(Node from, Node to);
    }
}
