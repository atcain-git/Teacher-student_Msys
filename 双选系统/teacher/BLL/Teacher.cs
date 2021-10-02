using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using Model;
using MODEL;
namespace BLL
{
    public class Teacher
    {

        public void login(){
            SQLDAL.Teacher t = new SQLDAL.Teacher();
            return ;
        }
    }

    public class TeacherLogic
    {
        TeacherDao teacherDao = new TeacherDao();

        public MODEL.Teacher UserLogin(MODEL.Teacher teacher)
        {

            return teacherDao.UserLogin(teacher);
        }

    }
}
