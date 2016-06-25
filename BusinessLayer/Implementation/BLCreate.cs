using BusinessLayer.Interface;
using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;
using Shared.JuegoEntities;
using DataLayer.Model;

namespace BusinessLayer.Implementation
{
    public class BLCreate : BLGenericCrud<DTCrearConfig>, IBLCreate
    {
        private BLActionConfig blAction = new BLActionConfig();

        protected IDALCreate _getDal()
        {
            return new DALCreate();
        }

        protected override IDALGenericCRUDDT<DTCrearConfig> getDal()
        {
            return _getDal();
        }

        public List<DTGameObject> GetAllGOBTime(int idGame)
        {
            List<DTGameObject> listGOB = blAction.getAllGOBForGame(idGame);
            List<DTGameObject> listReturn = new List<DTGameObject>();
            foreach (DTGameObject gob in listGOB)
            {
                foreach (DTAttribute atr in gob.attributes)
                {
                    if (atr.Type.Equals("3"))
                    {
                        listReturn.Add(gob);
                    }
                }
            }
            return listReturn;
        }
    }
}
