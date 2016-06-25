using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
    public class AttributeModel
    {
        public int id { get; set; }

        [Remote("IsAttributeNameAvailable", "Attribute", AdditionalFields = "id", ErrorMessage = "Name is already in use")]
        public string Name { get; set; }

        public string valor { get; set; }
        public int ID_GameObject { get; set; }
        public string Type { get; set; }
        public bool isSelected { get; set; }
    }
}