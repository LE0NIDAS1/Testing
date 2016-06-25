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
    public class BLGenerate : IBLGenerate
    {
        private IDALGenerate dalCost;

        public BLGenerate()
        {
            dalCost = new DALGenerate();
        }
        
        public BLGenerate(IDALGenerate _dalCost)
        {
            dalCost = _dalCost;
        }

        public void addGenerate(DTGenerate generate)
        {
            try
            {
                dalCost.addGenerate(generate);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteGenerate(int id)
        {
            try
            {
                dalCost.deleteGenerate(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTGenerate> getAllGenerates()
        {
            try
            {
                return dalCost.getAllGenerates();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTGenerate getGenerate(int id)
        {
            try
            {
                return dalCost.getGenerate(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateGenerate(DTGenerate generate)
        {
            try
            {
                dalCost.updateGenerate(generate);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
