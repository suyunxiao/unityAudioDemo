//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/18 20:50:26
 *  功能：装饰器基类
 */
//======================================================================================

using System;
using System.Collections.Generic;
using System.Reflection;

namespace RiggerIOC
{
    public interface IRiggerBase : IContext
    {

        /// <summary>
        /// 绑定装饰器
        /// </summary>
        //InjectorDecorator injectorAll { get; set; }

        /// <summary>
        /// 启动装饰器
        /// </summary>
        void OnStartRigger();

    }

    public static class RiggerBaseExtend
    {

        private static InjectorDecorator injectorAll = null;

        /// <summary>
        /// 初始化注入内容
        /// </summary>
        public static void InitFieldInfo(this IRiggerBase riggerBase)
        {
            InjectorDecorator injector = riggerBase.GetInjector();
            Type type = riggerBase.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.GetField | BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < fields.Length; ++i)
            {
                Type attType = null;
                var attcom = fields[i].GetCustomAttributes(typeof(DecoratorAttribute), false);
                if (0 < attcom.Length)
                {
                    DecoratorAttribute decoratorType = attcom[0] as DecoratorAttribute;
                    attType = decoratorType.type;
                    if (!injector.dataTypeDic.ContainsKey(attType))
                    {
                        object dataClass = Activator.CreateInstance(attType);
                        injector.dataTypeDic.Add(attType, dataClass);
                    }
                    fields[i].SetValue(riggerBase, injector.dataTypeDic[attType]);
                }
            }
            riggerBase.OnStartRigger();
        }

        /// <summary>
        /// 绑定
        /// </summary>
        public static void bindInjections(this IRiggerBase riggerBase)
        {
            //riggerBase.bindInjections();
        }

        /// <summary>
        /// 获取注入器
        /// </summary>
        public static InjectorDecorator GetInjector(this IRiggerBase riggerBase)
        {
            if (injectorAll == null)
            {
                injectorAll = new InjectorDecorator();
            }
            return injectorAll;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public static void Destroy(this IRiggerBase riggerBase)
        {
            //InjectorDecorator inject = riggerBase.GetInjector();
            //inject = null;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public static void DestroyAll(this IRiggerBase riggerBase)
        {
            InjectorDecorator inject = riggerBase.GetInjector();
            inject = null;
        }
    }

    

}
