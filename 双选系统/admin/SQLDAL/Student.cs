﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace SQLDAL
{
    public class Student
    {
        public DataTable getUnOrgnizeEnity(string grade,string major)
        {
            //LinkedList<Model.Student> students = new LinkedList<Model.Student>();  
            string sql = "select id '学号',name '姓名',grade'年级',college '学院',major '专业' from student where groupId is null and grade=@grade and major =@major";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@grade",grade),
                new SqlParameter ( "@major",major) 
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, paras);
            
            /*for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.Student student = new Model.Student();
                student.Id = dt.Rows[i]["id"].ToString();
                student.Major = dt.Rows[i]["major"].ToString();
                student.Name = dt.Rows[i]["name"].ToString();
                student.Grade = dt.Rows[i]["grade"].ToString();
                student.Grade = dt.Rows[i]["college"].ToString();
                students.AddLast(student);
            }
             
            return students.ToArray();
            */ 
            return dt;
        }

        public DataTable getEnity(string grade, string major,string del,object value)
        {
            DataTable dt = null;
            try
            {
                string sql;
                if (del.Equals("") && value.Equals(""))
                {
                    sql = "select id '学号',name '姓名',grade'年级',sex '性别',college '学院',major '专业',phone '联系电话',psw '密码' from student where grade=@grade and major =@major";
                }else{
                    sql = "select id '学号',name '姓名',grade'年级',sex '性别',college '学院',major '专业',phone '联系电话',psw '密码' from student where grade=@grade and major =@major and " + del + " like " +"'%"+value +"%'";
                }
                
                SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@grade",grade),
                new SqlParameter ( "@major",major),
             };
                dt = SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, paras);
                
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public DataTable getGroup(string grade,string major)
        {
            string sql = "select distinct student.id '学号',[groupp].project_name '项目名称', student.name '姓名',student.grade'年级',student.college '学院',student.major '专业',student.Class '班级',[groupp].groupid '组号' from student left JOIN [groupp] ON student.groupId = [groupp].groupid LEFT JOIN teacher on teacher.groupid = [groupp].groupid where student.grade = @grade and student.major = @major;";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@grade",grade),
                new SqlParameter ( "@major",major) 
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql,CommandType.Text,paras);

            return dt;
        }
    }
}
