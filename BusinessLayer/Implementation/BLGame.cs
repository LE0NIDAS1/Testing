using BusinessLayer.Interface;
using DataLayer.JuegoClasses;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.Helper;
using System.Threading.Tasks;

using System;

namespace BusinessLayer.Implementation
{
    public class BLGame : BLGenericCrud<DTGame>, IBLGame
    {
        protected IDALGame _getDal()
        {
            return new DALGame();
        }

        protected override IDALGenericCRUDDT<DTGame> getDal()
        {
            return _getDal();
        }

        public DTGame getForIdTenantIdentity(string tenantIdentity)
        {
            try
            {
                return _getDal().getForIdTenantIdentity(tenantIdentity);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        public bool isValid(string Name, int id)
        {
            try
            {
                return _getDal().isValid(Name, id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        public bool isValidDomain(string Domain, int id)
        {
            try
            {
                return _getDal().isValidDomain(Domain, id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }
        


    }
}
