using DataLayer.JuegoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.JuegoEntities;
using DataLayer.Helper;

namespace DataLayer.JuegoClasses
{
    public class DALGroup : IDALGroup
    {
        private AtlasConexion dbContext = new AtlasConexion();
        public void addGroup(DTGroup dt)
        {
            TABGroup tab = new TABGroup();
            tab.ID_GAME_FK = dt.idGame;            
            tab.Name = dt.Name;
            dbContext.TABGroup.Add(tab);
            dbContext.SaveChanges();
        }

        public void deleteGroup(int id)
        {
            dbContext.TABGroup.Remove(getTABGroup(id));
        }

        public List<DTGroup> getAllGroups()
        {
            List<DTGroup> list = new List<DTGroup>();
            return list = dbContext.TABGroup.Select(x => ConvertHelper.ConvertTABGroupToGroup(x)).ToList();
        }

        public DTGroup getGroup(int id)
        {
            DTGroup dt = new DTGroup();
            return ConvertHelper.ConvertTABGroupToGroup(dbContext.TABGroup.Where(x => x.ID == id).First());
        }

        public TABGroup getTABGroup(int id)
        {
            return dbContext.TABGroup.Where(x => x.ID == id).First();
        }

        public void updateGroup(DTGroup dt)
        {
            TABGroup tab = dbContext.TABGroup.Where(x => x.Name == dt.Name).First();
            foreach(DTGroupPlayer pl in dt.players)
            {
                tab.TABGroupPlayer.Add(ConvertHelper.convertGroupPlayerToTABGroupPlayer(pl));
            }
            tab.Name = dt.Name;
            dbContext.SaveChanges();
        }        
    }
}
