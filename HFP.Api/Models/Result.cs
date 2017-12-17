using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HFP.Api.Models.Enum;

namespace HFP.Api.Models
{
    public class Result
    {
        public Result()
        {
            Info = "操作失败";
            Data = null;
            StatusCode = StatusCode.失败;
        }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public dynamic Data { get; set; }
        /// <summary>
        /// 返回的状态码
        /// </summary>
        public StatusCode StatusCode { get; set; }
    }

    /// <summary>
    /// 状态码
    /// </summary>
    public enum StatusCode
    {
        成功 = 200,
        失败 = 400,
        参数错误 = 401,
        时间戳过期 = 402,
        程序错误 = 500
    }
}
