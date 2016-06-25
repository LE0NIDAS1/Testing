using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGenericCRUD<tab,dt>:IDALGenericCRUDDT<dt>
    {
		tab getForId(int id);
		List<tab> getAll();
		
        void create(tab obj);
		void update(tab obj);
		
        dt convertTABToDT(tab tab);
        tab convertDTToTAB(dt dt);
        
    }
}