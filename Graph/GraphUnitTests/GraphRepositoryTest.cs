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
            var nodes = repository.GetNodes();

            Assert.IsNotNull(nodes);
            Assert.IsTrue(nodes.Count>0);
        }
    }
}
