using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
    public class GameObjectModel
    {
        

        public int Id { get; set; }

        [Remote("IsGameObjectNameAvailable", "GameObject", AdditionalFields = "Id,IdCategory", ErrorMessage = "Name is already in use")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Image_file { get; set; }

        public int IdCategory { get; set; }

        public List<AttributeModel> attributes;

        public List<GenerateModel> generates;

        public List<CostModel> costes;

        public virtual CategoryModel CategoryModel { get; set; }

        public virtual AttributeModel AttributeModel { get; set; }

        public virtual GenerateModel GenerateModel { get; set; }

        public virtual CostModel CostModel { get; set; }
    }
}
