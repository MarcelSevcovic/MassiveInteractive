using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.DataAccess.Repository;
using Graph.Data.Model;

namespace Graph.Data.Business.Entity
{
    public interface IGraphEntity
    {

        GraphBase GraphData { get; }
        IEnumerable<int> CalculateShortestPath(Node from, Node to);


    }
}
