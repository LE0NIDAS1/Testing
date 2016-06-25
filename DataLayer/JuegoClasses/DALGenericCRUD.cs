using DataLayer.Helper;
using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.JuegoClasses
{
    public abstract class DALGenericCRUD<tab, dt> : IDALGenericCRUD<tab, dt> where tab : class
    {

        private AtlasConexion _dbContextAtlas { get; set; }

        protected AtlasConexion getDbContext()
        {
            if (_dbContextAtlas == null)
            {
                _dbContextAtlas = new AtlasConexion();
            }
            return _dbContextAtlas;
        }

        public abstract tab convertDTToTAB(dt dt);

        public abstract dt convertTABToDT(tab tab);

        public abstract tab getForId(int id);

        public void create(tab obj)
        {
            try
            {
                AtlasConexion dbContext = getDbContext();
                //processBeforeCreate(obj);
                dbContext.Set<tab>().Add(obj);              
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
            throw new Exception("error desconocido");
            }
        }

        protected abstract void processBeforeCreate(tab obj);

        public void createFromDt(dt obj)
        {
            create(convertDTToTAB(obj));
        }

        public void delete(int id)
        {
            try
            {
                AtlasConexion dbContext = getDbContext();
                tab obj = getForId(id);
                dbContext.Set<tab>().Remove(obj);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }

        }

        public List<tab> getAll()
        {
            try
            {
                AtlasConexion dbContext = getDbContext();
                return dbContext.Set<tab>().ToList();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }

        }

        public List<dt> getAllToDT()
        {
            return getAll().Select(x => convertTABToDT(x)).ToList();
        }

        public dt getToDTForId(int id)
        {
            return convertTABToDT(getForId(id));
        }

        public void update(tab obj)
        {
            try
            {
                AtlasConexion dbContext = getDbContext();
                dbContext.Set<tab>().Attach(obj);
                processBeforeUpdate(obj);
                dbContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }
        }

        protected abstract void processBeforeUpdate(tab obj);

        public void updateFromDt(dt obj)
        {
            tab objTab = convertDTToTAB(obj);
            update(objTab);
        }
    }
}