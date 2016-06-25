using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models.ActionModels
{
    public class SimpleAttackModel : ActionConfigModel
    {

        public int PercentLoss { get; set; }
        public int PercentGain { get; set; }
        public int ID_GAME_FK { get; set; }
        //public int ID_COST_FK { get; set; }

        public List<GameObjectModel> gameObjects;

        public virtual GameObjectModel gameObjectModel { get; set; }

    }
}