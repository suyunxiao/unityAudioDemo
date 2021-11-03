//======================================================================================
/**
 *  suchuan
 *  时间：2021/11/2 19:33:57
 *  功能：
 */
//======================================================================================

using Main.Debug;
using Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Monster
{
    public class FeudalLordMonster : HeroMonster
    {

        public override void Attack()
        {
            DebugLog.Instance.Log("attack");
        }

        public override void PassiveAttack()
        {
            DebugLog.Instance.Log("PassiveAttack");
        }

        public override void Die()
        {
            DebugLog.Instance.Log("Die");
        }

        public override void Move()
        {
            DebugLog.Instance.Log("Move");
        }

    }
}
