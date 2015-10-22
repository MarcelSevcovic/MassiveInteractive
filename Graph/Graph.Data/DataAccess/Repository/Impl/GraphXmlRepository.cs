using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Graph.Data.DataAccess.Mapper;
using Graph.Data.Model;

namespace Graph.Data.DataAccess.Repository.Impl
{
    public class GraphXmlRepository : IGraphRepository
    {
        private const string PATH = @"C:\Users\IBM_ADMIN\Source\Repos\MassiveInteractive\Graph\Input data";
        private const string SEARCH_PATTERN = "*.xml";

        public GraphBase GetUndirectedGraph()
        {
            return new UndirectedGraph(GetNodes());
        }

        public GraphBase GetDirectedGraph()
        {
            return new DirectedGraph(GetNodes());
        }

        private IEnumerable<Node> GetNodes()
        {
            var filesInDirectory = Directory.EnumerateFiles(PATH, SEARCH_PATTERN);
            var nodes = GetNodes(filesInDirectory);
            return nodes.Select(NodesMapper.MapFromXml).ToList();
        }

        private static IEnumerable<XmlNode> GetNodes(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var xDoc = new XmlDocument();
                xDoc.Load(file);

                yield return xDoc;
            }

        }
    }
}
