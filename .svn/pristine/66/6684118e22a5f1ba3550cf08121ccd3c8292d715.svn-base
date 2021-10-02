using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace SQLDAL
{
    public class Message
    {
        public bool insert(MODEL.Message mes)
        {
            string sql;
            if (!isExitence(mes))
            {
                sql = "insert into teacher(id,name,sex,college,grade,email,phone,major,guidance,Title,number) values(@id,@name,@sex,@college,@grade,@email,@phone,@major,@guidance,@title,@number)";
            }
            else
            {
                sql = "update teacher set name=@name,sex=@sex,college=@college,grade=@grade,email=@email,phone=@phone,major=@major,guidance=@guidance,Title=@title,number=@number where id=@id";
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
                new SqlParameter ( "@guidance",mes.Gudiance),
                new SqlParameter ( "@title",mes.Title),
                new SqlParameter ( "@number",mes.Number)
             };
            int count = SqlDbHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, paras);
            if (count == 1)
            {
                return true;
            }
            return false;
        }
        public bool isExitence(MODEL.Message mes)
        {
            string sql = "select count(*) from teacher where id = @id";
            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ("@id" ,mes.Id),
            };
            int count = (int)SqlDbHelper.ExecuteScalar(sql.ToString(), CommandType.Text, paras);
            if (count == 1)
            {
                return true;
            }
            return false;
        }
        public void slt_info(MODEL.Message mes)
        {
            string sql = "select id,psw,name,sex,college,grade,email,phone,major,guidance,Title,number from teacher where id = @id";
            SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ("@id" ,mes.Id),
            };
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), CommandType.Text, paras);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mes.Name = dt.Rows[i]["name"].ToString();
                mes.Psd = dt.Rows[i]["psw"].ToString();
                mes.Sex = dt.Rows[i]["sex"].ToString();
                mes.College = dt.Rows[i]["college"].ToString();
                mes.Grade = dt.Rows[i]["grade"].ToString();
                mes.Email = dt.Rows[i]["email"].ToString();
                mes.Phone = dt.Rows[i]["phone"].ToString();
                mes.Major = dt.Rows[i]["major"].ToString();
                mes.Gudiance = dt.Rows[i]["guidance"].ToString();
                mes.Title = dt.Rows[i]["Title"].ToString();
                mes.Number = int.Parse(dt.Rows[i]["number"].ToString());
            }
        }
    }
}
