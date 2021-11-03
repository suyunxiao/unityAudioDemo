//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/18 20:40:23
 *  功能：数据控制
 */
//======================================================================================

using DebugTool;
using Rigger.Modele;
using RiggerIOC;

namespace Rigger.Demo
{
    public class DemoServer: RiggerModle
    {
        [DecoratorAttribute (typeof (DemoModle))]
        public DemoModle modle;

        public void Init ()
        {
            DebugUtils.Warn("init server");
            modle.OutIndex ();
            modle.AddIndex ();
            modle.OutIndex ();
        }

    }
}
