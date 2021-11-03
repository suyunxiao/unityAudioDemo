using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure
{
    public class ProcotolType
    {
        public int id;

        /// <summary>
        /// 接收的协议的 id 和 次数 
        /// </summary>
        public Dictionary<int , int> receiveCode = new Dictionary<int , int> ();

        /// <summary>
        /// 发送的协议的 id 和 次数 
        /// </summary>
        public Dictionary<int , int> seedCode = new Dictionary<int , int> ();

        /// <summary>
        /// 协议的总流量长度
        /// </summary>
        public long procotolLength;

        /// <summary>
        /// 协议的总数
        /// </summary>
        public int codeSum;

        /// <summary>
        /// 开始统计协议的时间
        /// </summary>
        public DateTime beginCodeTime;

        /// <summary>
        /// 次数
        /// </summary>
        public long sum;

        /// <summary>
        /// 平均时间
        /// </summary>
        public long averageTime;

        /// <summary>
        /// 最长时间
        /// </summary>
        public long longTime;

        /// <summary>
        /// 最短时间
        /// </summary>
        public long shortTime;

        /// <summary>
        /// 总的执行时长
        /// </summary>
        public long sumSeedTime;

        /// <summary>
        /// 开始发送的时间
        /// </summary>
        public long beginSeedTime = -1;

        /// <summary>
        /// 开始发送的时间
        /// </summary>
        public string beginSeedStr;

    }
}
