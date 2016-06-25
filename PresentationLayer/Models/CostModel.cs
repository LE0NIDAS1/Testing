using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class CostModel
    {
        public int Id { get; set; }
        public int ID_GameObject { get; set; }
        public int id_Resource { get; set; }
        public int cant { get; set; }
    }
}