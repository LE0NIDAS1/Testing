using BusinessLayer.Interface;
using DataLayer.Helper;
using DataLayer.JuegoInterfaces;
using System;
using System.Collections.Generic;


namespace BusinessLayer.Implementation
{
    public abstract class BLGenericCrud<dt> : IBLGenericCRUD<dt>
    {
        protected abstract IDALGenericCRUDDT<dt> getDal();

        public virtual void create(dt obj)
        {
            try
            {
                getDal().createFromDt(obj);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        public void delete(int id)
        {
            try
            {
                getDal().delete(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
           
        }

        public List<dt> getAll()
        {
            try
            {
                return getDal().getAllToDT();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        public dt getForId(int id)
        {
            try
            {
                return getDal().getToDTForId(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        public void update(dt obj)
        {
            try
            {
                getDal().updateFromDt(obj);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }
    }
}
