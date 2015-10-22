using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Model
{
    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(IEnumerable<Node> nodes) : base(nodes)
        {
        }

        public override void AddRelation(Node from, Node to)
        {
            if (!from.AdjacentNodes.Exists(n => n.Id == to.Id))
                from.AdjacentNodes.Add(to);            
        }
    }
}
