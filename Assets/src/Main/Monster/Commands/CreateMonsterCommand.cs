//======================================================================================
/**
 *  suchuan
 *  时间：2021/11/2 19:30:16
 *  功能：
 */
//======================================================================================

using Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace RiggerIOC
{
    public class CreateMonsterCommand : RiggerCommand
    {
        private static int index = 1;

        public static FeudalLordMonster Create()
        {
            FeudalLordMonster monster = new FeudalLordMonster();
            monster.AT = 1;
            monster.HP = 100;
            monster.name = "敌人 " + index;
            return monster;
        }


    }
}
