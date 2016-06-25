using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTGroupPlayer
    {
        public int idGroup { get; set; }
        public int idPlayer { get; set; }
        public bool esAdmin { get; set; }
    }
}
