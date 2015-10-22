using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Business.Factory;
using Graph.Data.Business.Factory.Impl;
using Graph.Data.DataAccess.Repository.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphUnitTests
{
    [TestClass]
    public class GraphEntityTest
    {
        [TestMethod]
        public void CreateDirectedGraph()
        {
            //TODO use Mock
            IGraphFactory factory = new GraphFactory(new GraphXmlRepository());

            var entity = factory.CreateDirected();

            Assert.IsNotNull(entity);
            //TODO more asserts
        }


        [TestMethod]
        public void CreateUndirectedGraph()
        {
            //TODO use Mock
            IGraphFactory factory = new GraphFactory(new GraphXmlRepository());

            var entity = factory.CreateUndirected();

            Assert.IsNotNull(entity);
            //TODO more asserts
        }
    }
}
