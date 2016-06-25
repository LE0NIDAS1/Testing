using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.JuegoEntities
{
    public class DTPlayer
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Id { get; set; }
        public string tenantIdentity { get; set; }
        public int idGame { get; set; }
        public string Nick { get; set; }
        public string Picture { get; set; }
        public string TokenFacebook { get; set; }
        public string TokenGoogle { get; set; }
    }
}
