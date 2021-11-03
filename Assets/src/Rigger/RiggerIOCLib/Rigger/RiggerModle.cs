//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/14 16:15:52
 *  功能：装饰器modle
 */
//======================================================================================

namespace RiggerIOC
{
    public abstract class RiggerModle : IRiggerBase
    {

        /// <summary>
        /// 启动装饰器
        /// </summary>
        public void OnStartRigger()
        {

        }

        public RiggerModle()
        {
            this.InitFieldInfo();
        }

        /// <summary>
        /// 标识
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 释放
        /// </summary>
        public virtual void OnDestroy()
        {

        }

    }
}
