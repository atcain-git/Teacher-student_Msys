﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class Group
    {
        SQLDAL.Group dao = new SQLDAL.Group();
        public DataTable getGroup(string grade, string major, string tid)
        {
            return dao.get_Entity(grade, major, tid);
        }
        public DataTable getGroup(string tid)
        {
            return dao.get_Entity(tid);
        }
        public DataTable getGroups(string grade, string major, string tid)
        {
            return dao.get_Entitys(grade, major, tid);
        }
        public void del(int p, string tid,int i, out string msg)
        {
            dao.del(p,i, tid);
            msg = "修改成功";
        }
        public void Modefiy(int gid, Model.Group group, out string msg)
        {
            try {
                dao.Excute(group);
                msg = "提交成功";
            }
            catch(SqlException ex){
                throw (ex);
            }catch(Exception ex){
                throw(ex);
            }
            return ;
        }

        public void UpdateTea(int p, string tid, out string msg)
        {
            try
            {
                
                if (dao.Insert(p, tid))
                {
                    msg = "提交成功";
                }
                else
                {
                    msg = "提交失败";
                }
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return;
        }
    }
}
