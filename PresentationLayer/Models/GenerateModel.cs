using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class GenerateModel
    {
        public int Id { get; set; }
        public int Id_GameObject { get; set; }
        public int Id_Resource { get; set; }
        public string Resource { get; set; }
        public int time { get; set; }
        public int Quantity { get; set; }
    }
}