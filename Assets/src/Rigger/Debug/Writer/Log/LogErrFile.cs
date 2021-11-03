using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure
{
    class LogErrFile
    {
        private static List<string> _strList = new List<string> ();

        /// <summary>
        /// 线程锁标记，因为这个是启用多线程，避免同时操作一个文件报错。
        /// </summary>
        private static bool _isRead = false;

        private static string [] _outStrArr = new string [6];
        private static int _index = 0;

        public static void AddErrLogFileInRobot (string str)
        {
            if ( _index < 5 )
            {
                _outStrArr [_index] = DateTime.Now.TimeOfDay.ToString () + " " + str;
                _index++;
                return;
            }
            str = DateTime.Now.TimeOfDay.ToString () + " " + str;
            for ( int i = 0 ; i < _outStrArr.Length - 1 ; ++i )
            {
                str += "\n" + _outStrArr [i];
            }
            str += "\n";
            _index = 0;

            if ( _isRead )
            {
                _strList.Add (str);
                return;
            }
            _isRead = true;

            string netWord = "Assets/Scripts/Pressure/Log/robotLongTime.txt";
            Path.Combine ("Log" , netWord);
            if ( !Directory.Exists ("Log") )
            {
                Directory.CreateDirectory ("Log");
            }
            File.AppendAllText (netWord , str);
            if ( _strList.Count >= 1 )
            {
                string tips = _strList [0];
                _strList.RemoveAt (0);
                _isRead = false;
                AddErrLogFileInRobot (tips);
            }
            else
            {
                _isRead = false;
            }
        }
    }
}
