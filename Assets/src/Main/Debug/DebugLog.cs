//======================================================================================
/**
 *  suchuan
 *  时间：2021/11/2 19:35:47
 *  功能：
 */
//======================================================================================

using RiggerIOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Debug
{
    public class DebugLog :SingletonBase<DebugLog>
    {
        public void Log(string str)
        {
            UnityEngine.Debug.Log(str);
        }

        public void Warn(string str)
        {
            UnityEngine.Debug.LogWarning(str);
        }

        public void Err(string str)
        {
            UnityEngine.Debug.LogError(str);
        }
    }
}
