using System;
using System.Collections.Generic;
using MyApi.Attribute;

namespace ICore
{
    [ExportApi(typeof(ApiInvokeContext))]
    public sealed class ApiInvokeContext
    {
        public string RequestId = Guid.NewGuid().ToString();
        public string TrackingId { get;internal set; }
        public string Url { get;internal set; }
        public string Referer { get; internal set; }
        public string Token { get; internal set; }
        public string ClientIp { get; internal set; }
        public System.DateTimeOffset RequestTime { get; internal set; }
        public System.DateTimeOffset ResponseTime { get; internal set; }
        public Dictionary<string,object> Tags { get; internal set; }
    }
}
