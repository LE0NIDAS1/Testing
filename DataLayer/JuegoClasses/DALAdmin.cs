using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoClasses
{
    public class DALAdmin : IDALAdmin
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public bool loginAdmin(string email, string pass)
        {
            return dbContext.TABAdmin.Any(a => (((a.Email == email) && (a.Pass == pass))));
        }
    }
}
