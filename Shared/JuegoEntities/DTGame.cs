using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTGame
    {
        public int id { get; set; }
        public string name { get; set; }
        public string domain { get; set; }
        public string css { get; set; }
        public string state { get; set; }
        public int FacebookAppID { get; set; }
        public byte facebookAuth { get; set; }
        public string FacebookAppSecret { get; set; }
        public int GoogleClientID { get; set; }
        public string GoogleClientSecret { get; set; }
        public string IDAdmin { get; set; }
        public string Logo { get; set; }

        public List<DTGameObject> gameObjects { get; set; }
        public List<DTCategory> categories { get; set; }
        public List<DTResource> resources { get; set; }
        public List<DTActionConfig> actions { get; set; }

        public List<DTInitialGameObject> initialGO { get; set; }
        public List<DTInitialResource> initialR { get; set; }
    }
}
