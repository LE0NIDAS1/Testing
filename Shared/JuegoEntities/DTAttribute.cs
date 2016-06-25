using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTAttribute
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string valor { get; set; }
        public int idGameObject { get; set; }
        public string Type { get; set; }
    }
}
