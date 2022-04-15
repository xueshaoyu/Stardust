﻿using System;

namespace Stardust.Models
{
    /// <summary>生产服务信息</summary>
    public class PublishServiceInfo
    {
        /// <summary>服务名</summary>
        public String ServiceName { get; set; }

        /// <summary>客户端。IP加进程</summary>
        public String ClientId { get; set; }

        /// <summary>本地IP地址</summary>
        public String IP { get; set; }

        /// <summary>版本</summary>
        public String Version { get; set; }

        /// <summary>服务地址。本地局域网地址</summary>
        public String Address { get; set; }

        /// <summary>外部地址。经过网关之前的外部地址</summary>
        public String Address2 { get; set; }

        /// <summary>健康检测地址</summary>
        public String Health{ get; set; }

        /// <summary>标签。带有指定特性，逗号分隔</summary>
        public String Tag { get; set; }

        internal Func<String> AddressCallback;
    }
}