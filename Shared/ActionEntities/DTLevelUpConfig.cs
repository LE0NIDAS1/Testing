using Shared.JuegoEntities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared.ActionEntities
{
    [DataContract]
    public class DTLevelUpConfig : DTActionConfig
    {
        /*[DataMember]
        public int IDGameObject { get; set; }*/
        [DataMember]
        public int LevelUpCostrate { get; set; }
        [DataMember]
        public int LevelUpGenerateRate { get; set; }
        [DataMember]
        public int attributesRate { get; set; } 

        public List<DTAttribute> attributes { get; set; }
    }
}