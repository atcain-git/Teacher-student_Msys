using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MODEL;
using System.Data.SqlClient;
namespace SQLDAL
{
    public class Teacher
    {
    }

    public class TeacherDao
    {
        public MODEL.Teacher UserLogin(MODEL.Teacher teacher)
        {

            string sql = "select * from dbo.teacher where id=@id and psw=@psw";
            SqlParameter[] paras = new SqlParameter[]
                    {     
                        new SqlParameter ( "@id",teacher.UserId),
                        new SqlParameter ( "@psw",teacher.Password)
                    };

            try
            {
                SqlDataReader reader = SqlDbHelper.GetDataReader(sql, paras);
                if (reader.Read())
                {
                    teacher.UserId = reader["id"].ToString();
                }
                else
                { teacher = null; }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }
    }
}
