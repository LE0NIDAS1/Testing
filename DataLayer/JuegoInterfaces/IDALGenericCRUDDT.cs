using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGenericCRUDDT<dt>
    {
        dt getToDTForId(int id);
        List<dt> getAllToDT();
		
		void createFromDt(dt obj);
        void updateFromDt(dt obj);
        void delete(int id);
    }
}