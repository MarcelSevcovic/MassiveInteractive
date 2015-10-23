using System.Collections.Generic;
using Newtonsoft.Json;

namespace Graph.UI.Models
{
    public class GraphViewModel : AsSerializeable
    {
        public List<Node> nodes { get; set; }
        public List<Edge> edges { get; set; }
    }

    public class NodeData
    {
        public string id { get; set; }
        public string name { get; set; }
    }



    public class Node
    {
        public NodeData data { get; set; }

    }

    public class Edge
    {
        public EdgeData data { get; set; }
    }

    public class EdgeData
    {
        public string id { get; set; }


        public string source { get; set; }

        public string target { get; set; }

        public string colour { get; set; }
    }


    public abstract class AsSerializeable
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}