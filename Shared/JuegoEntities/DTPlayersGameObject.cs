using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTPlayersGameObject
    {
        public int idGameObject { get; set; }
        public bool isHold { get; set; }
        public TimeSpan timeToUnlock { get; set; }
        

    }
}
