using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;
using BusinessLayer.Interface;

namespace BusinessLayer.Implementation
{
    public class BLAdmin : IBLAdmin
    {
        private IDALAdmin dalAdmin = new DALAdmin();

        public BLAdmin()
        {
            dalAdmin = new DALAdmin();
        }

        public BLAdmin(IDALAdmin _dalAdmin)
        {
            dalAdmin = _dalAdmin;
        }

        public bool loginAdmin(string email, string pass)
        {
            try
            {
                return dalAdmin.loginAdmin(email, pass);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }
    }
}
