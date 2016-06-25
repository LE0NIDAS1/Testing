using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALCost
    {
        void addCost(DTCost cost);
        void deleteCost(int id);
        List<DTCost> getAllCosts();
        TABCost getTABCost(int id);
        DTCost getCost(int id);
        void updateCost(DTCost cost);
    }
}
