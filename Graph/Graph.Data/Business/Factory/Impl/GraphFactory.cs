using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Business.Entity;
using Graph.Data.Business.Entity.Impl;
using Graph.Data.DataAccess.Repository;

namespace Graph.Data.Business.Factory.Impl
{
    public class GraphFactory : IGraphFactory
    {

        private readonly IGraphRepository _graphRepository;


        public GraphFactory(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository;

        }

        public IGraphEntity CreateDirected()
        {
            return new GraphEntity(_graphRepository, true );
        }


        public IGraphEntity CreateUndirected()
        {
            return new GraphEntity(_graphRepository, false );
        }


    }
}
