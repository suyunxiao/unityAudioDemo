//======================================================================================
/**
 *  suchuan
 *  时间：2021/8/6 10:53:08
 *  功能：状态机的模板
 */
//======================================================================================

using System.Collections.Generic;
using System.Reflection;
using static Rigger.FSM.FSMServer;

namespace Rigger.FSM
{
    public class FSMModle 
    {
        //private static FSMModle _instance = null;

        //public static FSMModle Instance
        //{
        //    get
        //    {
        //        if ( _instance == null )
        //        {
        //            _instance = new FSMModle ();
        //        }
        //        return _instance;
        //    }
        //}

        private List<string> stateList = new List<string> ();

        private FSMServer m_fsm = new FSMServer ();

        public void Start (object data)
        {
            FieldInfo [] fields = data.GetType ().GetFields (BindingFlags.Public | BindingFlags.Instance);
            stateList.Clear ();
            foreach ( var f in fields )
            {
                var value = f.GetValue (data);
                stateList.Add (( string ) value);
            }
            m_fsm.Start (stateList);
        }

        /// <summary>
        /// 添加迁跃状态
        /// </summary>
        /// <param name="name">当前迁跃状态</param>
        /// <param name="transitionName">可达到的迁跃状态</param>
        /// <param name="transtionCall">迁跃后触发的回调</param>
        public void AddTransition (string name , string transitionName , FunBack transtionCall = null)
        {
            m_fsm.AddTransition (name, transitionName, transtionCall);
        }

    }
}
