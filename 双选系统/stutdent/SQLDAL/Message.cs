﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLDAL
{
    public class Message
    {
        public bool insert(Model.Message mes)
        {
            string sql;
            if (!isExitence(mes))
            {
                sql = "insert into student(id,name,sex,college,grade,email,phone,major,class,introduction) values(@id,@name,@sex,@college,@grade,@email,@phone,@major,@class,@introduction)";
            }
            else
            {
                sql = "update student set name=@name,sex=@sex,college=@college,grade=@grade,email=@email,phone=@phone,major=@major,class=@class,introduction=@introduction where id=@id";
            }
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@id",mes.Id), 
                new SqlParameter ( "@name",mes.Name), 
                new SqlParameter ( "@sex",mes.Sex), 
                new SqlParameter ( "@college",mes.College), 
                new SqlParameter ( "@grade",mes.Grade),
                new SqlParameter ( "@email",mes.Email),
                new SqlParameter ( "@phone",mes.Phone),
                new SqlParameter ( "@major",mes.Major),
                new SqlParameter ( "@class",mes.Class),
                new SqlParameter ( "@introduction",mes.Introduction)
             };
            int count = SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
            if (count == 1)
            {
                return true;
            }
            return false;
        }
        public bool isExitence(Model.Message mes)
        {
            string sql = "select count(*) from student where id = @id";
            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ("@id" ,mes.Id)
            };
            int count = (int)SqlDbHelper.ExecuteScalar(sql.ToString(), CommandType.Text, paras);
            if (count == 1)
            {
                return true;
            }
            return false;
        }
        public void slt_info(Model.Message mes)
        {
            string sql = "select id,name,sex,college,grade,email,phone,major,class,introduction from student where id = @id";
            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ("@id" ,mes.Id),
            };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mes.Name = dt.Rows[i]["name"].ToString();
                mes.Sex = dt.Rows[i]["sex"].ToString();
                mes.College = dt.Rows[i]["college"].ToString();
                mes.Grade = dt.Rows[i]["grade"].ToString();
                mes.Email = dt.Rows[i]["email"].ToString();
                mes.Phone = dt.Rows[i]["phone"].ToString();
                mes.Major = dt.Rows[i]["major"].ToString();
                mes.Introduction = dt.Rows[i]["introduction"].ToString();
                mes.Class = dt.Rows[i]["class"].ToString();
            }
        }
    }
}
