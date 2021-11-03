using System;

namespace Pressure
{
    public class WriteFileRobotCommand
    {

        private static WriteFileRobotCommand _instance = null;

        public static WriteFileRobotCommand Instance
        {
            get
            {
                if ( _instance == null )
                {
                    _instance = new WriteFileRobotCommand ();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        public void WriteInfo ()
        {
            DateTime endTime = DateTime.Now;
            //ProcotolType robotInfo = NetMgr.Ins.protocolSendReceiver.robotInfo;
            //long millPoto = (long)( endTime - robotInfo.beginCodeTime ).TotalMilliseconds / 1000;
            //int sumCode = 0;
            //foreach ( var item in robotInfo.seedCode)
            //{
            //    sumCode += item.Value;
            //}
            //foreach ( var item in robotInfo.receiveCode )
            //{
            //    sumCode += item.Value;
            //}
            //string centerTxt = $"\n time:{millPoto} allByte :{robotInfo.procotolLength}byte  averageTime(s):{robotInfo.procotolLength/millPoto}byte AllCodeSum:{sumCode} \n";
            //foreach ( var item in robotInfo.seedCode )
            //{
            //    centerTxt += $"\n  seedCodeId:{item.Key} seedCodeSum:{item.Value}";
            //}
            //foreach ( var item in robotInfo.receiveCode )
            //{
            //    centerTxt += $"\n  receiveCodeId:{item.Key} receiveCodeSum:{item.Value}";
            //}
            //LogFile.AddLogFile (centerTxt);
            //Console.WriteLine(centerTxt);
        }

    }
}
