using System.Runtime.Serialization;

namespace Shared.ActionEntities
{
    [DataContract]
    public class DTVenderConfig : DTActionConfig
    {
        [DataMember]
        public int PrecioSugericoXUnidad { get; set; }
    }
}