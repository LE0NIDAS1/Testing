using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTGroup
    {
        public int idGame { get; set; }
        public string Name { get; set; } 
        public List<DTGroupPlayer> players { get; set; }
    }
}
