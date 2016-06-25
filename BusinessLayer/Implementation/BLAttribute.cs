using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;

namespace BusinessLayer
{
    public class BLAttribute : IBLAttribute
    {
        private IDALAttribute dalAtr;

        public BLAttribute()
        {
            dalAtr = new DALAttribute();
        }

        public BLAttribute(IDALAttribute _dalAtr)
        {
            dalAtr = _dalAtr;
        }

        public void addAttribute(DTAttribute atr)
        {
            try
            {
                dalAtr.addAttribute(atr);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteAttribute(int id)
        {
            try
            {
                dalAtr.deleteAttribute(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTAttribute> getAllAttributes()
        {
            try
            {
                return dalAtr.getAllAttributes();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTAttribute getAttribute(int id)
        {
            try
            {
                return dalAtr.getAttribute(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public bool isValid(string Name, int id, int idGameObject)
        {
            try
            {
                return dalAtr.isValid(Name, id, idGameObject);
            }catch(Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateAttribute(DTAttribute atr)
        {
            try
            {
                dalAtr.updateAttribute(atr);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
