using HFP.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace HFP.Api.Filters
{
    public class ApiSecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Result result = new Result();

            //判断contentType是否有效
            var contentType = context.HttpContext.Request.ContentType;
            if (!contentType.Equals("application/json"))
            {
                result.Info = "contentType错误";
                result.StatusCode = StatusCode.参数错误;
                context.Result = new OkObjectResult(result);
                return;
            }

            //判断method是否有效
            var method = context.HttpContext.Request.Method;
            switch (method.ToUpper())
            {
                case "GET": break;
                case "POST": break;
                case "PUT": break;
                case "DELETE": break;
                default:
                    result.Info = "method错误";
                    result.StatusCode = StatusCode.参数错误;
                    context.Result = new OkObjectResult(result);
                    return;
            }

            //参数
            var content = context.ActionArguments;
            var token = content.FirstOrDefault(e => e.Key.ToLower().Equals("token")).Value;//令牌
            var nonce = content.FirstOrDefault(e => e.Key.ToLower().Equals("nonce")).Value;//随机字符串
            var timestamp = content.FirstOrDefault(e => e.Key.ToLower().Equals("timestamp")).Value;//时间戳
            var signature = content.FirstOrDefault(e => e.Key.ToLower().Equals("signature")).Value;//签名
            if (nonce == null || token == null || timestamp == null)
            {
                result.Info = "nonce或token或timestamp不为空";
                result.StatusCode = StatusCode.参数错误;
                context.Result = new OkObjectResult(result);
                return;
            }
            else
            {
                //判断timespan是否有效
                if (double.TryParse(timestamp.ToString(), out double timespanValidate))
                {
                    DateTime ts1 = DateTime.Now;
                    DateTime ts2 = DateTime.UtcNow.AddMilliseconds(timespanValidate);
                    TimeSpan timeSpan = ts2 - ts1;
                    if (timeSpan.TotalSeconds > 5)
                    {
                        result.Info = "时间戳过期";
                        result.StatusCode = StatusCode.时间戳过期;
                        context.Result = new OkObjectResult(result);
                        return;
                    }
                }
                else
                {
                    result.Info = "时间戳为double类型数据";
                    result.StatusCode = StatusCode.参数错误;
                    context.Result = new OkObjectResult(result);
                    return;
                }

                //验证token
                if (!ValidateToken(token.ToString()))
                {
                    result.Info = "验证token失败";
                    result.StatusCode = StatusCode.参数错误;
                    context.Result = new OkObjectResult(result);
                    return;
                }

                //验证签名(签名加密规则)
                string data = "";
                foreach (var item in content)
                {
                    data += item.Key + item.Value;
                }
                if (!signature.ToString().Equals(GetSignature(data)))
                {
                    result.Info = "验证签名失败";
                    result.StatusCode = StatusCode.参数错误;
                    context.Result = new OkObjectResult(result);
                    return;
                }
            }

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <returns></returns>
        private bool ValidateToken(string token)
        {
            return true;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetSignature(string data)
        {
            return MD5Encrypt(data);
        }

        ///   <summary>
        ///   给一个字符串进行MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }
    }
}
