using System;
using System.Collections.Generic;
using System.IO;

namespace Pressure
{
    class LogFile
    {
        public static void AddLogFile(string str)
        {
            string netWord = "AssetsCaches/chat";
            string fileName = "netWord.txt";
            string path2 = Path.Combine (netWord , fileName);
            if ( !Directory.Exists (path2) )
            {
                Directory.CreateDirectory (netWord);
                FileStream fs1 = new FileStream (path2 , FileMode.Create);
                fs1.Close ();
            }
            File.AppendAllText (path2 , str + "\n");
        }

        private static List<string> _strList = new List<string> ();

        /// <summary>
        /// 线程锁标记，因为这个是启用多线程，避免同时操作一个文件报错。
        /// </summary>
        private static bool _isRead = false;

        private static string []_outStrArr = new string [6];
        private static int _index = 0;

        private static string _str = "";

        private static readonly string path = "F:\\unity3d\\luna_test\\main_net_core\\src\\Pressure\\Log\\robot.txt";

        public static void AddLogFileInRobot (string str)
        {
            if ( _index < 5 )
            {
                _outStrArr [_index] = DateTime.Now.TimeOfDay.ToString () + " " + str;
                _index++;
                return;
            }
            string temp = DateTime.Now.TimeOfDay.ToString () + " " + str;
            str = "";
            for ( int i = 0 ; i < _outStrArr.Length - 1 ; ++i )
            {
                str += _outStrArr [i] + "\n";
            }
            _index = 0;
            str += temp + "\n";
            if ( _isRead)
            {
                _strList.Add (str);
                return;
            }
            _isRead = true;
            _str = str;
            AddLogFile();
        }

        public static void AddLogFile()
        {
            return;
            FileStream fs = new FileStream(path, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(_str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            if (_strList.Count >= 1)
            {
                string tips = _strList[0];
                _strList.RemoveAt(0);
                _isRead = false;
                AddLogFileInRobot(tips);
            }
            else
            {
                _isRead = false;
            }
        }

    }
}
