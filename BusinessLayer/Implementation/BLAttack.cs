using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.ActionEntities;
using DataLayer.JuegoClasses;
using DataLayer.JuegoInterfaces;


namespace BusinessLayer.Implementation
{
    public class BLAttack : IBLAttack
    {
        private IDALSimpleAttack dalSA = new DALSimpleAttack();


        public BLAttack()
        {
            dalSA = new DALSimpleAttack();
        }

        public BLAttack(IDALSimpleAttack _dalSA)
        {
            dalSA = _dalSA;
        }

        public void addSimpleAttack(DTSimpleAttack sAttack)
        {
            try
            {
                dalSA.addSimpleAttack(sAttack);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteSimpleAttack(int idSimpleAttack)
        {
            try
            {
                dalSA.deleteSimpleAttack(idSimpleAttack);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTSimpleAttack getSimpleAttack(int idSimpleAttack)
        {
            try
            {
                return dalSA.getSimpleAttack(idSimpleAttack);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public TABAttackConfig1 getTABSimpleAttack(int idSimpleAttack)
        {
            try
            {
                return dalSA.getTABSimpleAttack(idSimpleAttack);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            
            }
        }

        public void updateSimpleAttack(DTSimpleAttack sAttack)
        {
            try
            {
                dalSA.updateSimpleAttack(sAttack);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTSimpleAttack getSimpleAttackForIdGame(int idGame)
        {
            try
            {
                return dalSA.getSimpleAttackForIdGame(idGame);
            }
            catch(Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
