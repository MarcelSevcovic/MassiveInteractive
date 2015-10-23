using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Business.Entity.Helper;
using Graph.Data.DataAccess.Repository;
using Graph.Data.Model;

namespace Graph.Data.Business.Entity.Impl
{
    public class GraphEntity : IGraphEntity
    {
        private readonly IGraphRepository _repository;
        public GraphBase GraphData { get; private set; }

        public GraphEntity(IGraphRepository repository, bool directed)
        {
            if (repository == null)
                throw new Exception("Repository hasn't been loaded.");
            _repository = repository;
            GraphData = directed ? _repository.GetDirectedGraph() : _repository.GetUndirectedGraph();
            AddRelations();
        }

        public IEnumerable<int> CalculateShortestPath(Node from, Node to)
        {
            var b = new PathCalculator(GraphData, GraphData.Nodes.IndexOf(from));
            var path = b.PathTo(GraphData.Nodes.IndexOf(to));
            return path != null ? path.Select(i => GraphData.Nodes[i].Id).ToList() : null;
        }

        private void AddRelations()
        {
            foreach (var node in GraphData.Nodes)
            {
                foreach (var first in node.AdjacentIds.Select(adjacentId => GraphData.Nodes.FirstOrDefault(n => n.Id == adjacentId)))
                {
                    GraphData.AddRelation(node, first);
                }
            }
        }
    }
}
