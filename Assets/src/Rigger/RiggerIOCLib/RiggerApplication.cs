//======================================================================================
/**
*  suchuan
*  时间：2021/10/27 17:28:14
*  功能：
*/
//======================================================================================

using RiggerIOC;
using System.Collections.Generic;

namespace Rigger
{
    public abstract class RiggerApplication
    {

        private List<RiggerContext> riggerList = new List<RiggerContext>();

        /// <summary>
        /// 启动模块
        /// </summary>
        public virtual void Start()
        {
            AddContext(new MonsterContext());
            //riggerList.Add(new DemoContext());
        }

        /// <summary>
        /// 添加一个模块
        /// </summary>
        /// <param name="context"></param>
        public void AddContext(RiggerContext context)
        {
            riggerList.Add(context);
        }

        /// <summary>
        /// 关闭所有模块
        /// </summary>
        public virtual void Close()
        {
            for (int i = 0; i < riggerList.Count; ++i)
            {
                riggerList[i].Destroy();
            }
            riggerList.Clear();
        }

    }
}
