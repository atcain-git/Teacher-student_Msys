﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SQLDAL
{
    public class Group
    {
        public bool IsExistence(string uid,Model.Group m_group)
        {
            string sql = "select groupid from [groupp] where headman = @uid1 or mid1 = @uid2 or mid2 = @uid3 or mid3 = @uid4";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@uid1",uid), 
                new SqlParameter ( "@uid2",uid), 
                new SqlParameter ( "@uid3",uid), 
                new SqlParameter ( "@uid4",uid)
             };
            try {
                int gid = (int)SqlDbHelper.ExecuteScalar(sql.ToString(), CommandType.Text, paras);
                get_Entity(gid, m_group);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void get_Entity(int groupid, Model.Group m_group)
        {
            //string sql =
            //   "select student.name,student.id,project_introduction,project_name from student,groupp where student.groupId=groupp.groupid and groupp.groupid = @gid;";
            string sql = "SELECT s.name,s.id,project_introduction,project_name FROM [dbo].[groupp],dbo.student s where (mid1 = s.id or mid2 = s.id or mid3 = s.id or groupp.headman = s.id) and groupp.groupid = @gid;";
            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ( "@gid",groupid)
            };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            m_group.Gid = groupid;
            m_group.Pro_intro = dt.Rows[0]["project_introduction"].ToString(); ;
            m_group.Pro_name = dt.Rows[0]["project_name"].ToString();
            string[] ids = new string[4];
            string[] names = new string[4];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ids[i] = dt.Rows[i]["id"].ToString();
                names[i] = dt.Rows[i]["name"].ToString();
            }
            
            m_group.Hid = ids[0];
            m_group.Hid_name = names[0];
            m_group.Mid1 = ids[1];
            m_group.Mid1_name = names[1];
            m_group.Mid2 = ids[2];
            m_group.Mid2_name = names[2];
            m_group.Mid3 = ids[3];
            m_group.Mid3_name = names[3];
            

        }
        public void Excute(Model.Group m_group)
        {
            string sql = "update [groupp] set headman = @hid,mid1 = @mid1, mid2 = @mid2,mid3 = @mid3, project_name = @project_name, project_introduction= @project_introduction where groupid = @gid";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@hid",m_group.Hid), 
                new SqlParameter ( "@mid1",m_group.Mid1), 
                new SqlParameter ( "@mid2",m_group.Mid2), 
                new SqlParameter ( "@mid3",m_group.Mid3),
                new SqlParameter ( "@project_name",m_group.Pro_name),
                new SqlParameter ( "@project_introduction",m_group.Pro_intro),
                new SqlParameter ( "@gid",m_group.Gid)
             };
            SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
        }
        public void Insert(Model.Group m_group)
        {
            string sql = "insert into groupp(headman,mid1,mid2,mid3,project_name,project_introduction) values(@hid,@mid1,@mid2,@mid3,@project_name,@project_introduction)";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@hid",m_group.Hid), 
                new SqlParameter ( "@mid1",m_group.Mid1), 
                new SqlParameter ( "@mid2",m_group.Mid2), 
                new SqlParameter ( "@mid3",m_group.Mid3),
                new SqlParameter ( "@project_name",m_group.Pro_name),
                new SqlParameter ( "@project_introduction",m_group.Pro_intro)
             };
            SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
        }
        public bool isCanDoit(string uid)
        {
            string sql = "select * from groupp where headman= @uid";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ( "@uid",uid)
            };
            int i = (int)(SqlDbHelper.ExecuteScalar(sql.ToString(), CommandType.Text, paras)== null ? 0 : 1);
            //DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            //int i = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (i != 0)
            {
                return true;
            }
            return false ;
        }
    }
}
