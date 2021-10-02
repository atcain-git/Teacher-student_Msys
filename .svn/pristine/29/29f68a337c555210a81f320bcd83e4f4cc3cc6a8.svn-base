using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SQLDAL
{
    public class Teacher
    {
        public DataTable getTeachers(string grade,string major)
        {
            string sql = "select id '工号',name '姓名',grade '年级',sex '性别',Title '职称',phone '联系电话',psw '密码' from teacher where Grade = @grade and Major = @major";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@grade",grade),
                new SqlParameter ( "@major",major) 
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql, CommandType.Text,paras);
            return dt;
        }
    }
}
