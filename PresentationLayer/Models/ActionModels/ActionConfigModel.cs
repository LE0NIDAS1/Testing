using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class ActionConfigModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string TypeAction { get; set; }
        public List<string> ActionParameters { get; set; }
        public int IDGame { get; set; }
        public int idGameObject { get; set; }

        public virtual LevelUpModel levelup { get; set; }
    }
}