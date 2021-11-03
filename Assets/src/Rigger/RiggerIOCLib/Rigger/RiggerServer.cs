//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/27 17:11:07
 *  功能：装饰器的数据
 */
//======================================================================================

namespace RiggerIOC
{
    public abstract class RiggerServer : IRiggerBase
    {

        public RiggerServer()
        {
            this.InitFieldInfo();
        }

        /// <summary>
        /// 启动装饰器
        /// </summary>
        public void OnStartRigger()
        {
            AddEventList();
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        public virtual void AddEventList()
        {

        }

        /// <summary>
        /// 移除监听
        /// </summary>
        public virtual void RemoveEventList()
        {

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
            RemoveEventList();
        }

    }
}
