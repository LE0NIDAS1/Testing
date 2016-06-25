using System.Runtime.Serialization;

namespace Shared.ActionEntities
{
    [DataContract]
    public class DTDonarConfig : DTActionConfig
    {
        [DataMember]
        public int CantidadSugerida { get; set; }
    }
}