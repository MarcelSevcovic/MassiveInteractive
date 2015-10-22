using System;
using Graph.Data.DataAccess.Repository.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphUnitTests
{
    [TestClass]
    public class GraphRepositoryTest
    {
        [TestMethod]
        public void GetXmlData()
        {
            var repository = new GraphXmlRepository();
            var graph = repository.GetUndirectedGraph();

            Assert.IsNotNull(graph.Nodes);
            Assert.IsTrue(graph.Nodes.Count > 0);
        }

        
    }
}
