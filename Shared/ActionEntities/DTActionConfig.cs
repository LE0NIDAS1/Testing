using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ActionEntities
{
    [DataContract]
    [KnownType(typeof(DTSimpleAttack))]
    [KnownType(typeof(DTCrearConfig))]
    [KnownType(typeof(DTLevelUpConfig))]
    [KnownType(typeof(DTDonarConfig))]
    [KnownType(typeof(DTVenderConfig))]
    public abstract class DTActionConfig
    {
        [DataMember]
        public int idAction { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string TypeAction { get; set; }
        [DataMember]
        public List<string> ActionParameters { get; set; }
        [DataMember]
        public int IDGame { get; set; }
        [DataMember]
        public int IDGameObject { get; set; }
    }   
}
