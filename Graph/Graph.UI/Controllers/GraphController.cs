using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graph.UI.GraphInitService;
using Graph.UI.Models;

namespace Graph.UI.Controllers
{
    public class GraphController : Controller
    {
        public string Index()
        {
            return "Graphs";
        }

        public ActionResult DirectedGraph()
        {
            IGraphInitService service = new GraphInitServiceClient();
            var graph = PrepareDirectedGraphModel(service.GetDirectedGraph());
            return View(graph);

        }

        public ActionResult UndirectedGraph()
        {
            IGraphInitService service = new GraphInitServiceClient();
            var graph = PrepareUndirectedGraphModel(service.GetUndirectedGraph());
            return View(graph);

        }

        private static GraphViewModel PrepareDirectedGraphModel(IEnumerable<NodeDC> nodes)
        {
            var graph = new GraphViewModel();
            var graphNodes = new List<Node>();
            var graphEdges = new List<Edge>();

            foreach (var nodeDc in nodes)
            {
                graphNodes.Add(new Node { data = new NodeData() { id = nodeDc.Id.ToString(CultureInfo.InvariantCulture), name = nodeDc.Label } });
                graphEdges.AddRange(nodeDc.AdjacentIds.Select(adjacent => new Edge
                {
                    data = new EdgeData
                    {
                        id = String.Concat(nodeDc.Id.ToString(CultureInfo.InvariantCulture), "_", adjacent.ToString(CultureInfo.InvariantCulture)),
                        source = nodeDc.Id.ToString(CultureInfo.InvariantCulture),
                        target = adjacent.ToString(CultureInfo.InvariantCulture),
                        colour = "black"
                    }
                }));
            }

            graph.nodes = graphNodes;
            graph.edges = graphEdges;
            return graph;
        }



        private static GraphViewModel PrepareUndirectedGraphModel(IEnumerable<NodeDC> nodes)
        {
            var graph = new GraphViewModel();
            var graphNodes = new List<Node>();
            var graphEdges = new List<Edge>();



            foreach (var nodeDc in nodes)
            {
                graphNodes.Add(new Node { data = new NodeData() { id = nodeDc.Id.ToString(CultureInfo.InvariantCulture), name = nodeDc.Label } });

                foreach (var adjacent in nodeDc.AdjacentIds)
                {
                    if (
                        !graphEdges.Exists(
                            n =>
                                n.data.target == nodeDc.Id.ToString(CultureInfo.InvariantCulture) &&
                                n.data.source == adjacent.ToString(CultureInfo.InvariantCulture)))
                    {
                        graphEdges.Add(new Edge
                        {

                            data = new EdgeData
                            {
                                id =
                                    String.Concat(nodeDc.Id.ToString(CultureInfo.InvariantCulture), "_",
                                        adjacent.ToString(CultureInfo.InvariantCulture)),
                                source = nodeDc.Id.ToString(CultureInfo.InvariantCulture),
                                target = adjacent.ToString(CultureInfo.InvariantCulture),
                                colour = "black"
                            }
                        });
                    }
                }
            }

            graph.nodes = graphNodes;
            graph.edges = graphEdges;
            return graph;
        }
    }
}