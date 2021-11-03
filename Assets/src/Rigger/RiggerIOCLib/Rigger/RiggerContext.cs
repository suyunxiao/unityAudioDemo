//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/14 16:22:01
 *  功能：装饰器上下文
 */
//======================================================================================

namespace RiggerIOC
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RiggerContext : IRiggerBase
    {

        /// <summary>
        /// 启动装饰器
        /// </summary>
        public void OnStartRigger()
        {

        }

        public RiggerContext()
        {
            this.InitFieldInfo();
            bindInjections();
        }

        public virtual void bindInjections()
        {
            int i = 0;
        }



    }
}
