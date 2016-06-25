using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;
using BusinessLayer.Interface;

namespace BusinessLayer.Implementation
{
    public class BLLevelUp : BLGenericCrud<DTLevelUpConfig>, IBLLevelUp
    {

        protected IDALLevelUp _getDal()
        {
            return new DALLevelUp();
        }

        protected override IDALGenericCRUDDT<DTLevelUpConfig> getDal()
        {
            return _getDal();
        }
    }
}
