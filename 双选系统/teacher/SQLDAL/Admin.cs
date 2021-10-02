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
            string sql = "select psw from teacher where id = @id and id_card = @pid";
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
}
