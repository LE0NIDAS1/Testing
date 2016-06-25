using DataLayer.Helper;
using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using Shared.ActionEntities;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoClasses
{
    public class DALLevelUp : DALGenericCRUD<TABLevelUpConfig, DTLevelUpConfig>, IDALActionConfig, IDALLevelUp
    {
        public override TABLevelUpConfig convertDTToTAB(DTLevelUpConfig dt)
        {
            TABLevelUpConfig levelTAB = new TABLevelUpConfig();
            //foreach (DTAttribute attribute in dt.attributes)
            //{
            //       levelTAB.TABAttribute.Add(ConvertHelper.ConvertAttributeToTABAttribute(attribute));                
            //}
            levelTAB.ID_GAME_FK = dt.IDGame;
            levelTAB.Name = "Level up";
            levelTAB.ID_GAMEOBJECT = dt.IDGameObject;
            levelTAB.LevelUpCostRate = dt.LevelUpCostrate;
            levelTAB.LevelUpGenerateRate = dt.LevelUpGenerateRate;
            //levelTAB.LevelUpAttributesRate = dt.attributesRate;
            return levelTAB;
        }

        public override DTLevelUpConfig convertTABToDT(TABLevelUpConfig tab)
        {
            DTLevelUpConfig dt = new DTLevelUpConfig();
            dt.IDGame = tab.ID_GAME_FK;
            dt.name = "Level Up";
            dt.IDGameObject = tab.ID_GAMEOBJECT;
            dt.LevelUpCostrate = (int)tab.LevelUpCostRate;
            dt.LevelUpGenerateRate = (int)tab.LevelUpGenerateRate;            
            return dt;
        }

        public List<TABAttribute> getAllAttributesForGOB(int idGob)
        {
            throw new NotImplementedException();
        }

        public override TABLevelUpConfig getForId(int id)
        {
            throw new NotImplementedException();
        }

        protected override void processBeforeCreate(TABLevelUpConfig obj)
        {
            AtlasConexion dbContext = getDbContext();
            List<TABAttribute> attrDeBase = new List<TABAttribute>();
            //foreach (TABAttribute atr in obj.TABAttribute)
            //{
            //    attrDeBase.Add(dbContext.TABAttribute.Where(n => n.ID.Equals(atr.ID)).FirstOrDefault());
            //}
            //obj.TABAttribute.Clear();
            //attrDeBase.ForEach(n=> obj.TABAttribute.Add(n));
        }

        protected override void processBeforeUpdate(TABLevelUpConfig obj)
        {
            //throw new NotImplementedException();
        }
    }
}
