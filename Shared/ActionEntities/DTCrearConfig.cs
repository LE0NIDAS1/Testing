using Shared.JuegoEntities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared.ActionEntities
{
    [DataContract]
    public class DTCrearConfig : DTActionConfig
    {
        public List<DTGameObject> gameObjects { get; set; }
    }
}