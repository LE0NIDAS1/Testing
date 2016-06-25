using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALPlayer : IDALGenericCRUD<TABPlayer, DTPlayer>
    {
        bool validLogin(string userName, string password);

        TABPlayer getForId(string id);

        DTPlayer getToDTForId(string id);

        TABPlayer getForNick(string userName);

        DTPlayer getToDataTypeForNick(string userName);

        DTPlayer getToDTForEmail(string email);

        DTPlayer getForExternalLoginToDT(string loginProvider, string providerKey);

        TABPlayer getForExternalLogin(string loginProvider, string providerKey);

        List<DTPlayer> getRandomPlayerWithOutMe(string user, int cant);
    }
}
