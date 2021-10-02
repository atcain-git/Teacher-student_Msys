using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BLL
{
    public class Teacher
    {
        SQLDAL.Teacher teacher = new SQLDAL.Teacher();
        public DataTable getTeachers(string grade,string major)
        {
            return teacher.getTeachers(grade,major);
        }
    }
}
