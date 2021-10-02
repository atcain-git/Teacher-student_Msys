﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace SQLDAL
{
    public class Admin
    {
        public bool isExistence(Model.Admin admin,out string msg)
        {
            string sql = "select psw from admin where id = @id and pid = @pid";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@id" ,admin.Uid),
                new SqlParameter ( "@pid" ,admin.Pid) 
             };
            string psw = (string )SqlDbHelper.ExecuteScalar(sql.ToString(), CommandType.Text, paras);
            if (psw != null)
            {
                msg = psw;
                return true;
            }
            msg = "";
            return false;
        }

    }


        public class AdminDao
        {
            public Model.AAdmin UserLogin(Model.AAdmin admin)
            {

                string sql = "select * from dbo.admin where id=@id and psw=@psw";
                SqlParameter[] paras = new SqlParameter[]
                    {     
                        new SqlParameter ( "@id",admin.AdId),
                        new SqlParameter ( "@psw",admin.AdPsd)
                    };

                try
                {
                    SqlDataReader reader = SqlDbHelper.GetDataReader(sql, paras);
                    if (reader.Read())
                    {
                        admin.AdId = reader["id"].ToString();
                    }
                    else
                    { admin = null; }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return admin;
            }
        }
    

}

