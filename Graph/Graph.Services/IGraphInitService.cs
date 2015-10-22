using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Graph.Services.DataContract;

namespace Graph.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGraphInitService
    {

        [OperationContract]
        List<NodeDC> GetUndirectedGraph();
        
        
        [OperationContract]
        List<NodeDC> GetDirectedGraph();


    }


    
}
