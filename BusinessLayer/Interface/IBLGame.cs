using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLGame : IBLGenericCRUD<DTGame>
    {
        DTGame getForIdTenantIdentity(string tenantIdentity);
        bool isValid(string Name, int id);
        bool isValidDomain(string Domain, int id);
    }
}
