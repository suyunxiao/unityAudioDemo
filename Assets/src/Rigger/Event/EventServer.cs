//======================================================================================
/**
*  suchuan
*  时间：2021/8/5 17:30:45
*  功能：事件服务
*/
//======================================================================================


using System.Collections.Generic;
using System.Linq;

namespace Rigger.Event
{
    public class EventServer
    {
        private static EventServer _instance = null;

        public static EventServer Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new EventServer ();
                }
                return _instance;
            }
        }

        public delegate void CallBack (object a);

        public event CallBack Event;

        private Dictionary<string , List<CallBack>> eventDic = new Dictionary<string , List<CallBack>> ();

        private bool isHave = false;

        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="eventName">事件名字</param>
        /// <param name="callBack">回调</param>
        public void AddEventListener(string eventName, CallBack callBack)
        {
            if ( !eventDic.TryGetValue (eventName , out List<CallBack> callbackList) )
            {
                eventDic.Add (eventName,callbackList);
            }
            callbackList.Add (callBack);
        }

        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="eventName">事件名字</param>
        /// <param name="callBack">回调</param>
        public void RemoveEventListener (string eventName , CallBack callBack)
        {
            if ( !eventDic.TryGetValue (eventName , out List<CallBack> callbackList) )
            {
                var removeList = callbackList.FirstOrDefault (t => t == callBack);
                if (removeList != null)
                {
                    callbackList.Remove (removeList);
                }
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventName"></param>
        public void Dispatch(string eventName,object args)
        {
            if( eventDic.TryGetValue(eventName,out List<CallBack> callBackList) )
            {
                for(int i = 0 ; i < callBackList.Count ; ++i )
                {
                    callBackList [i].Invoke (args);
                }
            }
        }

        /// <summary>
        /// 清除所有的事件
        /// </summary>
        public void ClearEventListener()
        {
            eventDic.Clear ();
        }
    }
}
