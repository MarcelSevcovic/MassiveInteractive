using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Model;

namespace Graph.Data.Business.Entity.Helper
{
    //TODO - use IoC for this class, inject the object to the GraphEntity constructor
    public class PathCalculator
    {
        private const int INFINITY = int.MaxValue;
        private readonly bool[] _marked;  
        private readonly int[] _edgeTo;      
        private readonly int[] _distTo;      


        public PathCalculator(GraphBase graph, int sourceId)
        {
            _marked = new Boolean[graph.NodesCount]; 
            _distTo = new int[graph.NodesCount]; 
            _edgeTo = new int[graph.NodesCount]; 

            for (var v = 0; v < graph.NodesCount; v++) _distTo[v] = INFINITY;
            Search(graph, sourceId);
        }

        public IEnumerable<int> PathTo(int destinationId)
        {
            if (!HasPathTo(destinationId)) return null;
            var path = new Stack<int>();
            int x;
            for (x = destinationId; _distTo[x] != 0; x = _edgeTo[x])
                path.Push(x);
            path.Push(x);
            return path;
        }

        private void Search(GraphBase graph, int sourceId)
        {
            var queue = new Queue<int>();
            _marked[sourceId] = true;
            _distTo[sourceId] = 0;
            queue.Enqueue(sourceId);
            while (queue.Count > 0)
            {
                var nodeId = queue.Dequeue();
                foreach (var visited in graph.Adjacents(nodeId).Where(visited => !_marked[visited]))
                {
                    _edgeTo[visited] = nodeId;
                    _distTo[visited] = _distTo[nodeId] + 1;
                    _marked[visited] = true;
                    queue.Enqueue(visited);
                }
            }
        }

        private Boolean HasPathTo(int destinationId)
        {
            return _marked[destinationId];
        }
      
        

    }
}
