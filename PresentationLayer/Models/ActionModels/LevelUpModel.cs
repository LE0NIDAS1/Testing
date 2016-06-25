using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class LevelUpModel: ActionConfigModel
    {
        public int LevelUpCostRate { get; set; }
        public int LevelUpGenerateRate { get; set; }
        public int attributesRate { get; set; }

        public virtual GameObjectModel GameObject { get; set; }

    }
}