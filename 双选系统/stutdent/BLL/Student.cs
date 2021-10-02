using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using SQLDAL;
namespace BLL
{
    public class Student
    {
        StudentDao studentDao = new StudentDao();
        public Model.Student UserLogin(Model.Student student)
        {
            return studentDao.UserLogin(student);
        }
    }


}
