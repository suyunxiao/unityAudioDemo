using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure
{
    class LogSeedFile
    {
        private static readonly string path = "F:\\unity3d\\luna_test\\main_net_core\\src\\Pressure\\Log\\robot.txt";

        public static void AddLogFileInRobot (string str)
        {
            return;
            FileStream fs = new FileStream(path, FileMode.Append);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

    }
}
