using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Model
{
    public abstract class GraphBase
    {
        protected readonly LinkedList<int>[] _adjacents; //Use a LinkedList for the adjacency-list representation
        protected int _edgesCount;
        
        public List<Node> Nodes { get; private set; }

        public int NodesCount
        {
            get { return Nodes.Count(); }
        }
        
        protected GraphBase(IEnumerable<Node> nodes)
        {
            Nodes = new List<Node>();
            Nodes.AddRange(nodes);

            //Create a new adjecency-list for each node
            _adjacents = new LinkedList<int>[nodes.Count()];
            for (var i = 0; i < nodes.Count(); i++)
            {
                _adjacents[i] = new LinkedList<int>();
            }
        }

        public virtual void AddRelation(Node from, Node to)
        {
            _adjacents[Nodes.IndexOf(from)].AddFirst(Nodes.IndexOf(to));
            _edgesCount++;
        }

        public IEnumerable<int> Adjacents(int v)
        {
            if (v < 0 || v >= Nodes.Count) throw new Exception();
            return _adjacents[v];
        }

        
        


    }
}
