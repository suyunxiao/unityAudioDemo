//======================================================================================
/**
 *  suchuan
 *  时间：2021/8/31 20:05:17
 *  功能：
 */
//======================================================================================

namespace Rigger.ListFun
{
    public class ListFunDemo 
    {
        private static ListFunDemo _instance = null;

        public static ListFunDemo Instance
        {
            get
            {
                if ( _instance == null )
                {
                    _instance = new ListFunDemo ();
                }
                return _instance;
            }
        }

        public void Begin ()
        {
            ListFunModle listM = new ListFunModle ();
            //listM.AddItem (testFun);
        }

        //private void testFun (UnityAction call)
        //{
        //    if ( call != null )
        //    {
        //        call ();
        //    }
        //}

    }
}
