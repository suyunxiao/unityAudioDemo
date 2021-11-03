//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/22 20:14:07
 *  功能：
 */
//======================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebugTool
{
    public class DebugUtils 
    {
        public static void Log(string str)
        {
            WriteByColor(str, ConsoleColor.White);
        }

        public static void Warn(string str)
        {
            WriteByColor(str, ConsoleColor.Yellow);
        }

        public static void Err(string str)
        {
            WriteByColor(str, ConsoleColor.Red);
        }

        /// <summary>
        /// 输出带颜色的文本
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        public static void WriteByColor(string str, ConsoleColor color)
        {
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = currentForeColor;
        }

    }
}
