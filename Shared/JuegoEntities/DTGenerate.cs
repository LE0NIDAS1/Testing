﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTGenerate
    {
        public int id { get; set; } 
        public int idGameObject { get; set; }
        public int idResource { get; set; }
        public string resource { get; set; }
        public int time { get; set; }
        public int quantity { get; set; }
    }
}
