using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HFP.Api.Models;

namespace HFP.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int? staffId)
        {
            return Guid.NewGuid().ToString("N");

            //Result resultMsg = null;
            //int id = 0;

            ////判断参数是否合法
            //if (string.IsNullOrEmpty(staffId) || (!int.TryParse(staffId, out id)))
            //{
            //    resultMsg = new ResultMsg();
            //    resultMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
            //    resultMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();
            //    resultMsg.Data = "";
            //    return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
            //}

            ////插入缓存
            //Token token = (Token)HttpRuntime.Cache.Get(id.ToString());
            //if (HttpRuntime.Cache.Get(id.ToString()) == null)
            //{
            //    token = new Token();
            //    token.StaffId = id;
            //    token.SignToken = Guid.NewGuid();
            //    token.ExpireTime = DateTime.Now.AddDays(1);
            //    HttpRuntime.Cache.Insert(token.StaffId.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            //}

            ////返回token信息
            //resultMsg = new ResultMsg();
            //resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            //resultMsg.Info = "";
            //resultMsg.Data = token;

            //return HttpResponseExtension.toJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}