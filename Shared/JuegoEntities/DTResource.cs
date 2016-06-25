using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTResource
    {
        public int id { get; set; }
        public int idGame { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int count { get; set; }
    }
}
