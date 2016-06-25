using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTGameObject
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string image { get; set; }

        public int idCategory { get; set; }

        public List<DTAttribute> attributes { get; set; }

        public List<DTCost> costes { get; set; }

        public List<DTGenerate> generates { get; set; }

        public List<DTActionConfig> actions { get; set; }

        public List<DTEvent> events { get; set; }
    }
}

