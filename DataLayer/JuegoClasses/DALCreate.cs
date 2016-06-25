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
    public class DALCreate : DALGenericCRUD<TABCreateConfig, DTCrearConfig>, IDALActionConfig, IDALCreate
    {
        private IDALGameObject dalGob = new DALGameObect();
        public override TABCreateConfig convertDTToTAB(DTCrearConfig dt)
        {
            TABCreateConfig createTAB = new TABCreateConfig();
            createTAB.ID_GAME_FK = dt.IDGame;
            createTAB.Name = "Create";           
            createTAB.ID_GAMEOBJECT = dt.IDGameObject;
            return createTAB;
        }

        public override DTCrearConfig convertTABToDT(TABCreateConfig tab)
        {
            DTCrearConfig dt = new DTCrearConfig();
            dt.name = "Create";
            dt.IDGame = tab.ID_GAME_FK;
            dt.IDGameObject = tab.ID_GAMEOBJECT;            
            return dt;
        }

        public List<TABAttribute> getAllAttributesForGOB(int idGob)
        {
            throw new NotImplementedException();
        }

        public override TABCreateConfig getForId(int id)
        {
            throw new NotImplementedException();
        }

        protected override void processBeforeCreate(TABCreateConfig obj)
        {
            throw new NotImplementedException();
        }

        protected override void processBeforeUpdate(TABCreateConfig obj)
        {
            throw new NotImplementedException();
        }

    }
}
