//======================================================================================
/**
 *  suchuan
 *  时间：2021/8/5 20:43:13
 *  功能：有限状态机
 */
//======================================================================================

using System.Collections.Generic;

namespace Rigger.FSM
{
    public class FSMServer 
    {
        //private static FSMServer _instance = null;

        //public static FSMServer Instance
        //{
        //    get
        //    {
        //        if ( _instance == null )
        //        {
        //            _instance = new FSMServer ();
        //        }
        //        return _instance;
        //    }
        //}

        public delegate void FunBack (object a);

        /// <summary>
        /// 状态机总记录值
        /// </summary>
        private Dictionary<string , List<Dictionary<string , FunBack>>> m_transtionDic = new Dictionary<string , List<Dictionary<string , FunBack>>> ();

        /// <summary>
        /// 状态列表
        /// </summary>
        private List<string> m_stateList = new List<string> ();

        /// <summary>
        /// 是否已经存在该状态
        /// </summary>
        public bool m_isHaveTranstion = false;

        /// <summary>
        /// 当前状态索引
        /// </summary>
        private int m_stateIndex = 0;

        /// <summary>
        /// 启动状态机
        /// </summary>
        /// <param name="stateList"></param>
        public void Start (List<string> stateList)
        {
            m_stateList = stateList;
        }

        public void Stop()
        {
          
        }  

        public void Close()
        {

        }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(string state)
        {
            if ( m_transtionDic.TryGetValue (state,out List<Dictionary<string , FunBack>> transtionList) )
            {

            }
        }


        /// <summary>
        /// 添加迁跃状态
        /// </summary>
        /// <param name="name">当前迁跃状态</param>
        /// <param name="transitionName">可达到的迁跃状态</param>
        /// <param name="transtionCall">迁跃后触发的回调</param>
        public void AddTransition (string name,string transitionName, FunBack transtionCall)
        {
            if( m_transtionDic.TryGetValue(name,out List<Dictionary<string , FunBack>> transtionList) )
            {
                m_isHaveTranstion = false;
                for ( int i = 0 ; i < transtionList.Count ; i++ )
                {
                    if( transtionList[i].TryGetValue(transitionName,out FunBack FunBack) )
                    {
                        FunBack = transtionCall;
                        m_isHaveTranstion = true;
                    }
                }
                if ( m_isHaveTranstion || transtionList.Count <= 0)
                {
                    Dictionary<string , FunBack> t_addTranstion = new Dictionary<string , FunBack> ();
                    t_addTranstion.Add (transitionName, transtionCall);
                    transtionList.Add (t_addTranstion);
                    m_transtionDic [name] = transtionList;
                }
            }
            else
            {
                List<Dictionary<string , FunBack>> t_transtionList = new List<Dictionary<string , FunBack>> ();
                Dictionary<string , FunBack> t_dic = new Dictionary<string , FunBack> ();
                t_dic.Add (transitionName , transtionCall);
                t_transtionList.Add (t_dic);
                m_transtionDic.Add (name , t_transtionList);
            }
            
        }

    }
}
