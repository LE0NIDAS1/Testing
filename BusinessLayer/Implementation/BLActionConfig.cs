using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Implementation;
using Shared.ActionEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;
using DataLayer.Model;
using Shared.JuegoEntities;
using DataLayer.Helper;
using BusinessLayer.Interface;

namespace BusinessLayer.Implementation
{
    public class BLActionConfig : BLGenericCrud<DTActionConfig>, IBLActionConfig
    {

        public List<DTGameObject> getAllGOBForGame(int idGame)
        {
            DALGame dalGame = new DALGame();
            return dalGame.getAllGOBForGame(idGame).Select(x=> ConvertHelper.ConvertTABGameObjecttoGameObject(x)).ToList();
        }

        public List<DTAttribute> getAllAttributesForGOB(int idGob)
        {
            DALActionConfig dalAct = new DALActionConfig();
            return dalAct.getAllAttributesForGOB(idGob).Select(x => ConvertHelper.ConvertTABAtributeToAttribute(x)).ToList();
        }

        protected override IDALGenericCRUDDT<DTActionConfig> getDal()
        {
            throw new NotImplementedException();
        }

        //protected IDALActionConfig _getDal()
        //{
        //    return new DALActionConfig();
        //}
        //protected override DataLayer.JuegoInterfaces.IDALGenericCRUDDT<DTActionConfig> getDal()
        //{
        //    return _getDal();
        //}
    }
}
