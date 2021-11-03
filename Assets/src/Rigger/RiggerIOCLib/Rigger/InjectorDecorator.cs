//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/14 17:57:59
 *  功能：装饰器 - 注入器
 */
//======================================================================================

using System;
using System.Collections.Generic;

namespace RiggerIOC
{
    public class InjectorDecorator 
    {

        private readonly object lockObject = new object();

        /// <summary>
        /// 绑定的数据字典
        /// </summary>
        private Dictionary<int, object> bindData = new Dictionary<int, object>();

        /// <summary>
        /// 绑定的数据字典
        /// </summary>
        public Dictionary<Type , object> dataTypeDic = new Dictionary<Type , object> ();

        private int key = 1;

        /// <summary>
        /// 绑定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual SingletonModle<T> Bind<T>()
        {
            lock (lockObject)
            {
                object data = getKeyData(typeof(T));
                SingletonModle<T> data2;
                if (data == null)
                {
                    data2 = new SingletonModle<T>();
                    bindData.Add(key, data2);
                }
                else
                {
                    data2 = (SingletonModle<T>)data;
                }
                ++key;
                return data2;
            }
        }

        private object getKeyData(object obj)
        {
            foreach (var key in bindData)
            {
                if (key.Value.Equals(obj))
                {
                    return key.Value;
                }
            }
            return null;
        }

    }
}
