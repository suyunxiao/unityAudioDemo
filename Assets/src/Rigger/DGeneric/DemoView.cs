//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/28 17:01:48
 *  功能：
 */
//======================================================================================

using Rigger.Modele;
using RiggerIOC;
using RiggerIOCLib;

namespace ConsoleApp1.Decorator.DGeneric
{
    public class DemoView : ThirdView
    {
        [DecoratorAttribute(typeof(DemoModle))]
        public DemoModle modle1;

        public void Begin()
        {
            modle1.OutIndex();
            modle1.AddIndex();
            modle1.OutIndex();
        }


    }
}
