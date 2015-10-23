using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Graph.DataLoader.Repository
{
    public class LoadRepository
    {
        private const string PATH = @"C:\Users\IBM_ADMIN\Source\Repos\MassiveInteractive\Graph\Input data";
        private const string SEARCH_PATTERN = "*.xml";

        public void Load()
        {
            using (var context = new GraphEntities())
            {
                var nodes = context.Nodes;
                context.Nodes.RemoveRange(nodes);
                context.SaveChanges();         
                context.Nodes.AddRange(GetNodes());
                context.SaveChanges();
            }
        }



        private IEnumerable<Node> GetNodes()
        {
            var filesInDirectory = Directory.EnumerateFiles(PATH, SEARCH_PATTERN);
            var nodes = GetNodes(filesInDirectory);


            return nodes.Select(MapToSql).ToList();
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

        private static Node MapToSql(XmlNode xmlNode)
        {
            int id;
            if (!int.TryParse(xmlNode.SelectSingleNode("node").SelectSingleNode("id").InnerText, out id))
                throw new Exception("Unable to parse '" + xmlNode.SelectSingleNode("node").SelectSingleNode("id").InnerText + "'.");

            var label = xmlNode.SelectSingleNode("node").SelectSingleNode("label").InnerText;

            var node = new Node() {Id = id, Label = label};
            if (xmlNode.SelectSingleNode("node").SelectSingleNode("adjacentNodes").HasChildNodes)
            {
                var adjIds = GetAdjacents(xmlNode);
                foreach (var adjId in adjIds)
                {
                    node.AdjacentNodes1.Add(new AdjacentNode()
                    {
                        NodeId = node.Id,
                        AdjacentId = adjId
                    });
                }

            }

            return node;
        }

        private static IEnumerable<int> GetAdjacents(XmlNode node)
        {
            var adjs = node.SelectSingleNode("node").SelectSingleNode("adjacentNodes").SelectNodes("id");

            foreach (XmlNode adj in adjs)
            {
                int id;
                if (int.TryParse(adj.InnerText, out id))
                    yield return id;
                else
                    throw new Exception("Unable to parse '" + adj.InnerText + "'.");
            }
        }
    }
}
