//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/15 10:42:59
 *  功能：
 */
//======================================================================================

using System;

namespace RiggerIOC
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DecoratorAttribute: Attribute
    {
        public readonly Type type;

        public DecoratorAttribute(Type type)
        {
            this.type = type;
        }

    }

    /// <summary>
    /// 依赖注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class DecoratorInterfaceAttribute : Attribute
    {
        public readonly Type type;

        public DecoratorInterfaceAttribute(Type type)
        {
            this.type = type;
        }

    }
}
