using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return new Node(id, label);
        }

        public static Node MapFromDb()
        {
            throw new NotImplementedException();
        }
    }
}
