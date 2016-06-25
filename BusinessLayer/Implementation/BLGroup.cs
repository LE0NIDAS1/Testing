using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;

namespace BusinessLayer.Implementation
{
    public class BLGroup : IBLGroup
    {
        private IDALGroup dal = new DALGroup();

        public void addGroup(DTGroup gr)
        {
            dal.addGroup(gr);
        }

        public void deleteGroup(int id)
        {
            dal.deleteGroup(id);
        }

        public List<DTGroup> getAllGroups()
        {
            List<DTGroup> list = new List<DTGroup>();
            return dal.getAllGroups();
        }

        public DTGroup getGroup(int id)
        {
            return dal.getGroup(id);
        }

        public void updateGroup(DTGroup gr)
        {
            dal.updateGroup(gr);
        }
    }
}
