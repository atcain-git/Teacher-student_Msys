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
        public DataTable get_Entitys(string grade,string major,string tid)
        {
            string sql =
                "SELECT [groupp].groupid '小组编号',[groupp].project_name '项目名称',s1.name '队长',s2.name '队员',s3.name '队员',s4.name '队员',first '第一志愿',secondd'第二志愿',third '第三志愿' FROM [groupp] LEFT JOIN [student] s1 ON s1.id = [groupp].headman LEFT JOIN [student] s2 ON s2.id = [groupp].mid1 LEFT JOIN [student] s3 ON s3.id = [groupp].mid2  LEFT JOIN [student] s4 ON s4.id = [groupp].mid3 where s1.Grade = @Grade and s1.Major = @major and groupp.groupid in (select [groupp].groupid from groupp EXCEPT(select c1 from t,teacher where teacher.id = @tid and teacher.id = t.tid  union select c2 from t,teacher where teacher.id =@tid and teacher.id = t.tid union select c3 from t,teacher where teacher.id = @tid and teacher.id = t.tid union select c4 from t,teacher where teacher.id = @tid and teacher.id = t.tid union select c5  from t,teacher where teacher.id = @tid and teacher.id = t.tid))";
            SqlParameter[] paras = new SqlParameter[]
             {                  
                new SqlParameter ( "@Major",major), 
                new SqlParameter ( "@grade",grade),
                new SqlParameter ( "@tid",tid),
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
          
            return dt;
        }
        public DataTable get_Entity(string grade,string major,string tid)
        {
            string sql =
                "SELECT g1,g2,g3,g4,g5 from teacher,t where teacher.id = @tid and teacher.id = t.tid";
            SqlParameter[] paras = new SqlParameter[]
             {                  
                new SqlParameter ( "@tid",tid)
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            dt.Columns.Add("志愿顺序", Type.GetType("System.Int32"));
            DataTable data = new DataTable();
            sql =
                "SELECT groupp.groupid '组号', groupp.project_name,groupp.project_introduction from groupp where groupp.groupid = @g1";
            DataRow dr = dt.AsEnumerable().First();
            for (int i = 1; i <= 4; i++)
            {
                SqlParameter[] par = new SqlParameter[]
             {                  
                new SqlParameter ( "@g1",dr["g"+i])
             };
                data.Merge(SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, par));
            }

            data.Rows[1].Delete();
            /*
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m_group.Gid = groupid;
                m_group.Hid = dt.Rows[i]["id1"].ToString();
                m_group.Hid_name = dt.Rows[i]["name1"].ToString();
                m_group.Mid1 = dt.Rows[i]["id2"].ToString();
                m_group.Mid1_name = dt.Rows[i]["name2"].ToString();
                m_group.Mid2 = dt.Rows[i]["id3"].ToString();
                m_group.Mid2_name = dt.Rows[i]["name3"].ToString();
                m_group.Mid3 = dt.Rows[i]["id4"].ToString();
                m_group.Mid3_name = dt.Rows[i]["name4"].ToString();
                m_group.Pro_intro = dt.Rows[i]["project_introduction"].ToString();
                m_group.Pro_name = dt.Rows[i]["project_name"].ToString();
            }
             */
            return data;
        }
        public DataTable get_Entity(string tid)
        {
            string sql =
                "SELECT c1,c2,c3,c4,c5 from teacher,t where teacher.id = @tid and teacher.id = t.tid";
            SqlParameter[] paras = new SqlParameter[]
             {                  
                new SqlParameter ( "@tid",tid)
             };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            DataTable data = new DataTable();
            sql =
                "SELECT groupp.groupid '组号', groupp.project_name,groupp.project_introduction from groupp where groupp.groupid = @g1";
            DataRow dr = dt.AsEnumerable().First();
            for (int i = 1; i <= 4; i++)
            {
                SqlParameter[] par = new SqlParameter[]
             {                  
                new SqlParameter ( "@g1",dr["c"+i])
             };
                data.Merge(SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, par));
            }


            /*
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m_group.Gid = groupid;
                m_group.Hid = dt.Rows[i]["id1"].ToString();
                m_group.Hid_name = dt.Rows[i]["name1"].ToString();
                m_group.Mid1 = dt.Rows[i]["id2"].ToString();
                m_group.Mid1_name = dt.Rows[i]["name2"].ToString();
                m_group.Mid2 = dt.Rows[i]["id3"].ToString();
                m_group.Mid2_name = dt.Rows[i]["name3"].ToString();
                m_group.Mid3 = dt.Rows[i]["id4"].ToString();
                m_group.Mid3_name = dt.Rows[i]["name4"].ToString();
                m_group.Pro_intro = dt.Rows[i]["project_introduction"].ToString();
                m_group.Pro_name = dt.Rows[i]["project_name"].ToString();
            }
             */
            return data;
        }
        public void Excute(Model.Group m_group)
        {
            string sql = "update [group] set headman = s1.id,mid1 = s2.id, mid2 = s3.id,mid3 = s4.id, project_name = @project_name, first=@first,second=@second,@third"
            + "where groupid = @gid and (s1.name = @HidName or s2.name = @name2 or s3.name = @name3 or s4.name = @name4) FROM [groupp]" +
                " LEFT JOIN [student] s1 ON s1.id = [groupp].headman LEFT JOIN [student] s2 ON s2.id = [groupp].mid1 LEFT JOIN [student] s3 ON s3.id = [groupp].mid2 "
                + "LEFT JOIN [student] s4 ON s4.id = [groupp].mid3;"; ;
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@HidName",m_group.Hid_name), 
                new SqlParameter ( "@name2",m_group.Mid1_name), 
                new SqlParameter ( "@name3",m_group.Mid2_name), 
                new SqlParameter ( "@name4",m_group.Mid3_name),
                new SqlParameter ( "@project_name",m_group.Pro_name),
                new SqlParameter ( "@first",m_group.First),
                new SqlParameter ( "@second",m_group.Second),
                new SqlParameter ( "@third",m_group.Thrid),
                new SqlParameter ( "@gid",m_group.Gid)
             };
            SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
        }
        public void Insert(Model.Group m_group)
        {
            string sql = "insert into [group](headman,mid1,mid2,mid3,project_name,project_introduction) values(@hid,@mid1,@mid2,@mid3,@project_name,@project_introduction)";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@hid",m_group.Hid), 
                new SqlParameter ( "@mid1",m_group.Hid), 
                new SqlParameter ( "@mid2",m_group.Mid1), 
                new SqlParameter ( "@mid3",m_group.Mid3),
                new SqlParameter ( "@project_name",m_group.Pro_name),
                new SqlParameter ( "@project_introduction",m_group.Pro_intro)
             };
            SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
        }
        public void del(int p,int i,string tid)
        {
            string sql = "update t set c"+i+"=null where tid = " + tid;
            SqlDbHelper.ExecuteNonQuery(sql.ToString());
        }

        public bool Insert(int gid,string tid)
        {
            try
            {
                for (int i = 1; i <= 5; i++) {
                    string sql = "update t set c" + i + "= @gid where tid = @tid and c" + i + " is null";
                    SqlParameter[] paras = new SqlParameter[]
                 {     
                    new SqlParameter ( "@gid",gid), 
                    new SqlParameter ( "@tid",tid) 
                 };
                    int j = SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
                    if (j == 1)
                    {
                        return true;
                    }
                }
                

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex) {
                throw ex;
            }
            return false;
        }
    }
}
