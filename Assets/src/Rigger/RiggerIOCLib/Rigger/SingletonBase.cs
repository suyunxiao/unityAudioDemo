//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/14 16:54:58
 *  功能：单例
 */
//======================================================================================

namespace RiggerIOC
{
    /// <summary>
    /// 单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonBase<T> where T : new()
    {
        private static T instance;

        public static T Instance
        {
            get 
            { 
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }

        /// <summary>
        /// 是否设置类为单例
        /// </summary>
        private bool isSingleton = false;

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public T GetInstance()
        {
            if (isSingleton)
            {
                return instance;
            }
            else
            {
                return new T();
            }
        }

        /// <summary>
        /// 设置为单例
        /// </summary>
        public virtual void ToSingleton()
        {
            isSingleton = true;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public virtual void Destroy()
        {

        }
    }
}
