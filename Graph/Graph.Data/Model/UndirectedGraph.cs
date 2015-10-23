using System.Collections.Generic;

namespace Graph.Data.Model
{
    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(IEnumerable<Node> nodes) : base(nodes)
        {
        }

        public override void AddRelation(Node from, Node to)
        {
            if (!from.AdjacentNodes.Exists(n => n.Id == to.Id))
                from.AdjacentNodes.Add(to);
            if (!to.AdjacentNodes.Exists(n => n.Id == from.Id))
                to.AdjacentNodes.Add(from);
            if (!from.AdjacentIds.Exists(n => n == to.Id))
                from.AdjacentIds.Add(to.Id);
            if (!to.AdjacentIds.Exists(n => n == from.Id))
                to.AdjacentIds.Add(from.Id);

            base.AddRelation(from, to);

        }
    }
}
