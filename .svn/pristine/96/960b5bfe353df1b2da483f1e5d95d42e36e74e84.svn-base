using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace SQLDAL
{
    public class Time
    {
        public bool Update_time(Model.Time time)
        {
            string sql = "update commit_time set start_write = @c1,stop_write = @c2 , start_admission = @c3 , stop_admission = @c4 where id = 1";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@c1" ,time.D1),
                new SqlParameter ( "@c2" ,time.D2),
                new SqlParameter ( "@c3" ,time.D3),
                new SqlParameter ( "@c4" ,time.D4) 
             };
            int i = SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
