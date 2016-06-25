using DataLayer.Model;
using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALSimpleAttack
    {
        void addSimpleAttack(DTSimpleAttack sAttack);
        void deleteSimpleAttack(int idSimpleAttack);
        TABAttackConfig1 getTABSimpleAttack(int idSimpleAttack);
        DTSimpleAttack getSimpleAttack(int idSimpleAttack);
        void updateSimpleAttack(DTSimpleAttack sAttack);
        DTSimpleAttack getSimpleAttackForIdGame(int idGame);
    }
}
