using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTInitialResource
    {
        public int idResource { get; set; }

        public string Name { get; set; }

        public int idGame { get; set; }

        public int quantity { get; set; }
    }
}
