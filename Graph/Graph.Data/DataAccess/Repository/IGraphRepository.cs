using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Model;

namespace Graph.Data.DataAccess.Repository
{
    public interface IGraphRepository
    {
        GraphBase GetUndirectedGraph();

        GraphBase GetDirectedGraph();
    }
}
