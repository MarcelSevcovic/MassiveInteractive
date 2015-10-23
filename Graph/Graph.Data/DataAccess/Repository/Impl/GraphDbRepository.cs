using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.DataAccess.Mapper;
using Graph.Data.DataAccess.ORM;
using Graph.Data.Model;
using Node = Graph.Data.Model.Node;

namespace Graph.Data.DataAccess.Repository.Impl
{
    public class GraphDbRepository : IGraphRepository
    {
        public GraphBase GetUndirectedGraph()
        {
            return new UndirectedGraph(GetNodes());
        }

        public GraphBase GetDirectedGraph()
        {
            return new DirectedGraph(GetNodes());
        }

        private IEnumerable<Node> GetNodes()
        {            
            using (var context = new GraphEntities())
            {
                foreach (var node in context.Nodes)
                {
                    yield return NodesMapper.MapFromDb(node);
                }               
            }           
        }

        
    }
}
