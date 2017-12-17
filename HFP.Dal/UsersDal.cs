using Dapper;
using HFP.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HFP.Dal
{
    class UsersDal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Users (@ID,@Name)");

            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", 1);
            param.Add("@Name", "cx");

            return DapperMySQLHelp.ExcuteNonQuery<Users>("", sql.ToString(), param) > 0;

            //param.Add("_pagecount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //var result = mysql.FindToListByPage<Person>(connection, "page_getperson", param);
            ////总条数
            //var count = param.Get<int>("_pagecount");
            //var kk = result;
        }
    }
}
