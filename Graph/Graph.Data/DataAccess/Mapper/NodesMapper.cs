using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Graph.Data.Model;

namespace Graph.Data.DataAccess.Mapper
{
    public static class NodesMapper
    {

        public static Node MapFromXml(XmlNode node)
        {
            int id;
            if (!int.TryParse(node.SelectSingleNode("node").SelectSingleNode("id").InnerText, out id))
                throw new Exception("Unable to parse '" + node.SelectSingleNode("node").SelectSingleNode("id").InnerText + "'.");

            var label = node.SelectSingleNode("node").SelectSingleNode("label").InnerText;

            if (node.SelectSingleNode("node").SelectSingleNode("adjacentNodes").HasChildNodes)
                return new Node(id, label, GetAdjacents(node));

            return new Node(id, label);
        }              

        public static Node MapFromDb(ORM.Node sqlNode)
        {
            if (sqlNode.AdjacentNodes != null)
            {
                return new Node(sqlNode.Id, sqlNode.Label, sqlNode.AdjacentNodes1.Select(adj => adj.AdjacentId).ToList());
            }
            return new Node(sqlNode.Id, sqlNode.Label);
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
