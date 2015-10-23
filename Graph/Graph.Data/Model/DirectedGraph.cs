using System.Collections.Generic;

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
            if (!from.AdjacentIds.Exists(n => n == to.Id))
                from.AdjacentIds.Add(to.Id);
            base.AddRelation(from, to);
        }
    }
}
