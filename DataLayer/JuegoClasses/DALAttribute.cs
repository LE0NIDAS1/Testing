using DataLayer.JuegoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.JuegoEntities;
using static Shared.JuegoEntities.DTAttribute;
using DataLayer.Helper;

namespace DataLayer.JuegoClasses
{
    public class DALAttribute : IDALAttribute
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addAttribute(DTAttribute atr)
        {
            TABAttribute atrTab = new TABAttribute();
            atrTab.ID_GAMEOBJECT_FK = atr.idGameObject;
            atrTab.Name = atr.nombre;
            atrTab.Value = atr.valor;
            atrTab.Type = atr.Type;
            dbContext.TABAttribute.Add(atrTab);
            dbContext.SaveChanges();
        }

        public void deleteAttribute(int id)
        {
            dbContext.TABAttribute.Remove(getTABAttribute(id));
            dbContext.SaveChanges();
        }

        public List<DTAttribute> getAllAttributes()
        {
            List<DTAttribute> listaAtrturn = new List<DTAttribute>();
            List<TABAttribute> listaBase = dbContext.TABAttribute.ToList();
            foreach (TABAttribute TABAttribute in listaBase)
            {
                listaAtrturn.Add(ConvertHelper.ConvertTABAtributeToAttribute(TABAttribute));
            }
            return listaAtrturn;
        }
       
        public DTAttribute getAttribute(int id)
        {
            DTAttribute atr = ConvertHelper.ConvertTABAtributeToAttribute(dbContext.TABAttribute.Where(n => n.ID == id).First());
            return atr;
        }

        public TABAttribute getTABAttribute(int id)
        {
            return dbContext.TABAttribute.Where(n => n.ID == id).First();
        }

        public void updateAttribute(DTAttribute atr)
        {
            TABAttribute atrTAB = dbContext.TABAttribute.Where(n => n.ID == atr.id).First();
            atrTAB.Name = atr.nombre;
            atrTAB.ID_GAMEOBJECT_FK = atr.idGameObject;
            atrTAB.Value = atr.valor;
            atrTAB.Type = atr.Type;
            dbContext.SaveChanges();
        }

        public bool isValid(string Name, int id, int idGameObject)
        {

            return dbContext.TABAttribute.Any(a => (((a.ID != id) && (a.Name == Name)) && (a.ID_GAMEOBJECT_FK == idGameObject)));
        }

        public bool gameObjectAttack(int idGameObject)
        {
            return dbContext.TABAttribute.Any(a => (a.ID_GAMEOBJECT_FK == idGameObject) && (a.Name == "Ataque"));
        }

        public bool gameObjectDefend(int idGameObject)
        {
            return dbContext.TABAttribute.Any(a => (a.ID_GAMEOBJECT_FK == idGameObject) && (a.Name == "Defensa"));
        }

        public int valueAttack(int idGameObject)
        {
            return Int32.Parse(dbContext.TABAttribute.Where(a => (a.ID_GAMEOBJECT_FK == idGameObject) && (a.Name == "Ataque")).First().Value);
        }

        public int valueDefense(int idGameObject)
        {
            return Int32.Parse(dbContext.TABAttribute.Where(a => (a.ID_GAMEOBJECT_FK == idGameObject) && (a.Name == "Defensa")).First().Value);
        }
    }
}
