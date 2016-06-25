using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ActionEntities
{
    [DataContract]
    public class DTSimpleAttack
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PercentLoss { get; set; }
        public int PercentGain { get; set; }
        public int ID_GAME_FK { get; set; }
        

        public List<DTGameObject> gameObjects;
    }
}
