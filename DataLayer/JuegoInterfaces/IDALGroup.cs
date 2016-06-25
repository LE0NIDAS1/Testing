using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGroup
    {
        void addGroup(DTGroup dt);
        void deleteGroup(int id);
        List<DTGroup> getAllGroups();
        TABGroup getTABGroup(int id);
        DTGroup getGroup(int id);
        void updateGroup(DTGroup dt);
        //List<DTGroup> getGroupsByGameId(int id);
        //List<DTGroup> getGroupsByGameName(string name);
        //List<DTGroup> getRGroupesByGameTenant(string tenantIdentity);
    }
}
