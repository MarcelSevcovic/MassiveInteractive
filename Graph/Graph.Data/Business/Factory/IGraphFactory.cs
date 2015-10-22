using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Business.Entity;

namespace Graph.Data.Business.Factory
{
    public interface IGraphFactory
    {
        IGraphEntity CreateDirected();

        IGraphEntity CreateUndirected();
    }
}
