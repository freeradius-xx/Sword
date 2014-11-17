﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandBus
{
    [Serializable]
    public class Command
    {
        public string SessionID { get; set; }

        /// <summary>
        /// 调用方AppID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// 需要调用的Contract接口所在命名空间
        /// </summary>
        public string CallContractNamespace { get; set; }

        /// <summary>
        /// 需要调用的Contract接口
        /// </summary>
        public string CallContract { get; set; }

        /// <summary>
        /// 需要调用的方法/函数名
        /// </summary>
        public string Method2Invoke { get; set; }

        /// <summary>
        /// 相应的版本号，如果默认则留空，如: null或者string.Empty
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 调用参数
        /// </summary>
        public List<object> Arguments { get; set; }
    }
}