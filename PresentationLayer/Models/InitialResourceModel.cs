using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public partial class InitialResourceModel
    {
        [Key]
        public int idResource { get; set; }

        public string Name { get; set; }

        public int IdGame { get; set; }

        public int Quantity { get; set; }
    }
}