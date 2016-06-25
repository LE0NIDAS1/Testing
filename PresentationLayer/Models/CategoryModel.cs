using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public string Image { get; set; }
        public string Image_file { get; set; }
        public int ID_Game { get; set; }

        public List<GameObjectModel> gameObjects { get; set; }

        public virtual GameObjectModel GameObject { get; set; }
    }
}
