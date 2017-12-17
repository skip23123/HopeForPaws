using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HFP.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //DynamicParameters param = new DynamicParameters();
            //param.Add("_pageIndex", 2);
            //param.Add("_pageSize", 5);
            //param.Add("_pagecount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //var result = mysql.FindToListByPage<Person>(connection, "page_getperson", param);
            ////总条数
            //var count = param.Get<int>("_pagecount");
            //var kk = result;
        }
    }
}
