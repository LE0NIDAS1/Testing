using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGame : IDALGenericCRUD<TABGame, DTGame>
    {
        DTGame getForIdTenantIdentity(string tenantIdentity);
        bool isValid(string Name, int id);
        bool isValidDomain(string Domain, int id);
    }
}
