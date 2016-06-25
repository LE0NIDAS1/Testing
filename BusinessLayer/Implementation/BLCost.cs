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
    public class BLCost : IBLCost
    {
        private IDALCost dalCost;

        public BLCost()
        {
            dalCost = new DALCost();
        }
        
        public BLCost(IDALCost _dalCost)
        {
            dalCost = _dalCost;
        }

        public void addCost(DTCost cost)
        {
            try
            {
                dalCost.addCost(cost);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteCost(int id)
        {
            try
            {
                dalCost.deleteCost(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTCost> getAllCosts()
        {
            try
            {
                return dalCost.getAllCosts();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTCost getCost(int id)
        {
            try
            {
                return dalCost.getCost(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateCost(DTCost cost)
        {
            try
            {
                dalCost.updateCost(cost);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
