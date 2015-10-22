using System.Collections.Generic;
using AutoMapper;
using Graph.Data.Business.Factory;
using Graph.Data.IoC;
using Graph.Data.IoC.Impl;
using Graph.Data.Model;
using Graph.Services.DataContract;

namespace Graph.Services
{
    public class GraphInitService : IGraphInitService
    {
        private IDataServiceLocator _serviceLocator;
        private readonly IGraphFactory _graphFactory;


        public GraphInitService()
        {
            _serviceLocator = new DataServiceLocator();
            _graphFactory = _serviceLocator.GetGraphService<IGraphFactory>();
            Mapper.CreateMap<Node, NodeDC>();
        }

        public List<NodeDC> GetUndirectedGraph()
        {
            var graphEntity = _graphFactory.CreateUndirected();           
            return MapToDataContract(graphEntity.GraphData.Nodes);

        }

        public List<NodeDC> GetDirectedGraph()
        {
            var graphEntity = _graphFactory.CreateDirected();
            return MapToDataContract(graphEntity.GraphData.Nodes);
        }

        private List<NodeDC> MapToDataContract(List<Node> nodes)
        {
            var nodesDC = new List<NodeDC>();
            if (nodes != null) nodes.ForEach(n => nodesDC.Add(Mapper.Map<NodeDC>(n)));
            return nodesDC;
        }
    }
}
