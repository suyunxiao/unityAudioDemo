//======================================================================================
/**
 *  suchuan
 *  时间：2021/11/2 19:10:47
 *  功能：英雄类型的人物
 */
//======================================================================================

using UnityEngine.UI;

namespace Monster
{
    public abstract class HeroMonster : IMonster
    {

        public int HP;

        public int AT;

        public string name;

        public virtual void Attack()
        {
            throw new System.NotImplementedException();
        }

        public virtual void PassiveAttack()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Die()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
