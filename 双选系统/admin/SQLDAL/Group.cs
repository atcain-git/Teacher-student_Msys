using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLDAL
{
    public class Group
    {
        public DataTable getGroupInfo(int gid, string tid)
        {
            string sql = "(select groupp.groupid '组号',student.name '队长姓名',student.grade '年级',groupp.project_name '项目名称',groupp.project_introduction '项目介绍',teacher.name '老师姓名' from teacher,groupp,student where groupp.headman = student.id and groupp.groupid = @gid and teacher.id = @tid)";

            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@gid",gid),
                new SqlParameter ( "@tid",tid) 
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, paras);
            return dt;
        }
    }
}
