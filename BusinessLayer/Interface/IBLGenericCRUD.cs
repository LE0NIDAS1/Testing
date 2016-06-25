using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLGenericCRUD<dt>
    {
        void create(dt obj);
        dt getForId(int id);
        void update(dt obj);
        void delete(int id);
        List<dt> getAll();     
    }
}
