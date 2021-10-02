using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
namespace SQLDAL
{
    class Student
    {
    }
    public class StudentDao
    {
        public Model.Student UserLogin(Model.Student student)
        {
            string sql = "select * from dbo.student where id=@id and psw=@psw";
            SqlParameter[] paras = new SqlParameter[]
            {     
                        new SqlParameter ( "@id",student.StuId),
                        new SqlParameter ( "@psw",student.StuPsd)
            };
            try
            {
                SqlDataReader reader = SqlDbHelper.GetDataReader(sql, paras);
                if (reader.Read())
                {
                    student.StuId = reader["id"].ToString();
                }
                else
                { student = null; }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return student;      
        }
    }
}
