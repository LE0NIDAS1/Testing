using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
    public class GameModel
    {
        public int id { get; set; }

        [Remote("IsGameNameAvailable", "Game", AdditionalFields = "id", ErrorMessage = "Name is already in use")]
        public string name { get; set; }

        [Remote("IsGameDomainAvailable", "Game", AdditionalFields = "id", ErrorMessage = "Domain is already in use")]
        public string domain { get; set; }

        public string css { get; set; }
        public string css_file { get; set; }
        public string state { get; set; }
        public int FacebookAppID { get; set; }
        public Byte facebookAuth { get; set; }
        public string FacebookAppSecret { get; set; }
        public int GoogleClientID { get; set; }
        public string GoogleClientSecret { get; set; }
        public string IDAdmin { get; set; }
        public string Logo { get; set; }
        public string Logo_File { get; set; }

        public List<CategoryModel> categories { get; set; }
        public List<ResourceModel> resources { get; set; }
        public List<GameObjectModel> gameObjects { get; set; }
        public List<ActionConfigModel> actions { get; set; }
        //public List<InitialInstanceModel> initials { get; set; }
        public List<InitialGameObjectModel> iniGameObjects { get; set; }
        public List<InitialResourceModel> iniResource { get; set; }


        public virtual CategoryModel CategoryModel { get; set; }
        public virtual ResourceModel resourceModel { get; set; }
        public virtual GameObjectModel gameObjectModel { get; set; }
        //public virtual InitialInstanceModel initialInstanceModel { get; set; }
        public virtual InitialGameObjectModel initialGameObjectModel { get; set; }
        public virtual InitialResourceModel InitialResourceModel { get; set; }
    }
}
