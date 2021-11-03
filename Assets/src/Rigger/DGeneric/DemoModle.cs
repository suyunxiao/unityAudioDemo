//======================================================================================
/**
*  suchuan
*  时间：2021/10/14 16:18:46
*  功能：
*/
//======================================================================================

using DebugTool;
using RiggerIOC;

namespace Rigger.Modele
{
    public class DemoModle : RiggerModle
    {
        private int index = 1;

        public void OutIndex ()
        {
            DebugUtils.Warn("index:" + index);
        }

        public void AddIndex ()
        {
            ++index;
        }

    }
}
