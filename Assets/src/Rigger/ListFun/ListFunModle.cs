//======================================================================================
/**
 *  suchuan
 *  时间：2021/8/31 19:44:23
 *  功能：队列方式调用模板
 */
//======================================================================================

using System.Collections.Generic;

namespace Rigger.ListFun
{
    public class ListFunModle
    {
        public delegate void EventAction(object a);

        private List<EventAction> funList = new List<EventAction> ();


        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            if ( funList.Count > 0 )
            {

            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Destroy ()
        {
            funList.Clear ();
        }

        /// <summary>
        /// 添加子项
        /// </summary>
        /// <param name="funList"></param>
        public void AddItem(EventAction call)
        {
            funList.Add (call);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Stop ()
        {

        }

        private void call ()
        {

        }



    }
}
