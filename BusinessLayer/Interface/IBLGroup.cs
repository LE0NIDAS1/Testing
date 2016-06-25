using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLGroup
    {
        void addGroup(DTGroup gr);
        void deleteGroup(int id);
        List<DTGroup> getAllGroups();
        DTGroup getGroup(int id);
        void updateGroup(DTGroup gr);
    }
}
