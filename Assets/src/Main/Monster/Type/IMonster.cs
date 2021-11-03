//======================================================================================
/**
 *  suchuan
 *  时间：2021/11/2 17:29:14
 *  功能：人物接口
 */
//======================================================================================


namespace Monster
{
    public interface IMonster
    {

        /// <summary>
        /// 攻击
        /// </summary>
        void Attack();

        /// <summary>
        /// 被攻击
        /// </summary>
        void PassiveAttack();

        /// <summary>
        /// 死亡
        /// </summary>
        void Die();

        /// <summary>
        /// 移动
        /// </summary>
        void Move();

    }
}
