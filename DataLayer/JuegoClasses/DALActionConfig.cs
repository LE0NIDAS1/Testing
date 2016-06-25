using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoClasses
{
    public class DALActionConfig : DALGenericCRUD<TABActionConfig,DTActionConfig>, IDALActionConfig
    {

        public override TABActionConfig convertDTToTAB(DTActionConfig dt)
        {
            throw new NotImplementedException();
        }

        public override DTActionConfig convertTABToDT(TABActionConfig tab)
        {
            throw new NotImplementedException();
        }

        public override TABActionConfig getForId(int id)
        {
            throw new NotImplementedException();
        }

        public List<TABAttribute> getAllAttributesForGOB(int idGob)
        {
            AtlasConexion dbContext = getDbContext();
            return dbContext.TABAttribute.Where(x => x.ID_GAMEOBJECT_FK == idGob).ToList();
        }

        protected override void processBeforeCreate(TABActionConfig obj)
        {
            //throw new NotImplementedException();
        }

        protected override void processBeforeUpdate(TABActionConfig obj)
        {
            //throw new NotImplementedException();
        }
    }
}
