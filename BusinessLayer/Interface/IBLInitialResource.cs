using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLInitialResource
    {
        void addInitialResource(DTInitialResource ires);
        void deleteInitialResource(int idGame, int idResource);
        List<DTInitialResource> getAllInitialResource();
        DTInitialResource getInitialResource(int idGame, int idResource);
        void updateInitialResource(DTInitialResource ires);
    }
}
