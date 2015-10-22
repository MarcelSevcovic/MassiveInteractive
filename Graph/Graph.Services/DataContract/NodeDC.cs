using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Graph.Services.DataContract
{
    [DataContract]
    public class NodeDC
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public List<int> AdjacentIds { get; set; }
         
    }
}