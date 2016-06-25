using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTNotification
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ID_PLAYER_FK { get; set; }

        public bool hasRead { get; set; }
    }
}
