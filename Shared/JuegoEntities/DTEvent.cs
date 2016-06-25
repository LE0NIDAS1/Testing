using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTEvent
    {
        public int id { get; set; }
        public DateTime expiration { get; set; }
        public int? id_notification { get; set; }

        public List<DTGameObject> gameobjects { get; set; }
    }
}
