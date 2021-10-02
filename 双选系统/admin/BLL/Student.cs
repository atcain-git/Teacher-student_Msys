using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class Student
    {
        SQLDAL.Student dao = new SQLDAL.Student();
        public DataTable getUnOrgnizeEnity(string grade,string major)
        {
            return dao.getUnOrgnizeEnity(grade, major);
        }

        public DataTable getEnitity(string grade, string major,string del,string value)
        {
            try
            {
                if (del == "姓名")
                {
                    del = "name";
                }
                else if (del == "班级")
                {
                    del = "class";
                    int tmp = int.Parse(value);
                    return dao.getEnity(grade, major, del, tmp);
                }
                return dao.getEnity(grade, major,del,value);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getGroup(string grade,string major)
        {
            return dao.getGroup(grade ,major);
        }
    }
}
