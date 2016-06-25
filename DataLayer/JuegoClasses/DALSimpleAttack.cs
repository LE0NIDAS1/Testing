using DataLayer.JuegoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.ActionEntities;
using DataLayer.Helper;

namespace DataLayer.JuegoClasses
{
    public class DALSimpleAttack : IDALSimpleAttack
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addSimpleAttack(DTSimpleAttack sAttack)
        {
            SimpleAttack sAttackTAB = new SimpleAttack();
            sAttackTAB.ID_GAME_FK = sAttack.ID_GAME_FK;
            sAttackTAB.Name = sAttack.Name;
            sAttackTAB.PercentGain = sAttack.PercentGain;
            sAttackTAB.PercentLoss = sAttack.PercentLoss;
            dbContext.TABAttackConfig1Set.Add(sAttackTAB);
            dbContext.SaveChanges();
        }

        public void deleteSimpleAttack(int idSimpleAttack)
        {
            dbContext.TABAttackConfig1Set.Remove(getTABSimpleAttack(idSimpleAttack));
            dbContext.SaveChanges();
        }

        public DTSimpleAttack getSimpleAttack(int idSimpleAttack)
        {
            DTSimpleAttack simpleAttackDT = ConvertHelper.ConvertTABSimpleAttackTOSimpleAttack(dbContext.TABAttackConfig1Set.Where(n => n.ID == idSimpleAttack).First());
            return simpleAttackDT;
        }

        public TABAttackConfig1 getTABSimpleAttack(int idSimpleAttack)
        {
            TABAttackConfig1 saTAB = dbContext.TABAttackConfig1Set.Where(n => n.ID == idSimpleAttack).First();
            return saTAB;
        }

        public void updateSimpleAttack(DTSimpleAttack sAttack)
        {
            TABAttackConfig1 saTAB = dbContext.TABAttackConfig1Set.Where(n => n.ID == sAttack.ID).First();
            if (saTAB.GetType() == typeof(SimpleAttack))
            {
                SimpleAttack SA = (SimpleAttack)saTAB;
                SA.ID_GAME_FK = sAttack.ID_GAME_FK;
                SA.Name = sAttack.Name;
                SA.PercentGain = SA.PercentGain;
                SA.PercentLoss = SA.PercentLoss;
            }
            dbContext.SaveChanges();
        }

        public DTSimpleAttack getSimpleAttackForIdGame(int idGame)
        {
            DTSimpleAttack simpleAttackDT = ConvertHelper.ConvertTABSimpleAttackTOSimpleAttack(dbContext.TABAttackConfig1Set.Where(n => n.ID_GAME_FK == idGame).First());
            return simpleAttackDT;
        }
    }
}
