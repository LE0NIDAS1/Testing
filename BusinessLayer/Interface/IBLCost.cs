using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBLCost
    {
        void addCost(DTCost cost);
        void deleteCost(int id);
        List<DTCost> getAllCosts();
        DTCost getCost(int id);
        void updateCost(DTCost cost);
    }
}
