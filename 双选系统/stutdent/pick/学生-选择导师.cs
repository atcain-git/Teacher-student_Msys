using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLDAL;
using System.Data.SqlClient;
namespace pick
{
    public partial class 选择导师 : Form
    {
        public 选择导师()
        {
            InitializeComponent();
            Table();
        }
        private string uid;
        private bool b1 = false;
        private bool b2 = false;
        private bool b3 = false;
        public 选择导师(string uid)
        {
            InitializeComponent();
            Table();
            this.uid = uid;
        }
        //从数据库读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();
            DAO dao = new DAO();
            string sql = "select id,name,number,introduction from teacher";
            IDataReader dc = dao.read(sql, null);
            string a0, a1, a2, a3;
            while (dc.Read())
            {
                MODEL.Teacher t = new MODEL.Teacher();
                t.Id = a0 = dc[0].ToString();
                t.Name = a1 = dc[1].ToString();
                t.Number = a2 = dc[2].ToString();
                t.Introduction = a3 = dc[3].ToString();
                string[] table = { a0, a1, a2, a3 };
                dataGridView1.Rows.Add(table);

            }
            dc.Close();
        }
        private void 选择导师_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
        }
        //设置一个窗口全局变量存储老师工号
         string a = null;
         string b = null;
         string c = null;
        
        private void 提交_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text || textBox4.Text == textBox5.Text || textBox5.Text == textBox3.Text)
            {

                MessageBox.Show("志愿有重复项，请修改");
            }
            else
            {


                //MessageBox.Show(a+b+c);
                DAO dao = new DAO();
                string sql = "select groupid from groupp where mid1 = @uid or mid2 = @uid or mid3 = @uid or headman = @uid";
                SqlParameter[] paras = new SqlParameter[]
            { 
                new SqlParameter ( "@uid",uid)
            };
                int gid = (int)SQLDAL.SqlDbHelper.ExecuteScalar(sql, CommandType.Text, paras);
                sql = "update dbo.g set c1=" + a + ",c2=" + b + ",c3=" + c + "where gid=" + gid;
                int n = dao.Execute(sql);
                if (n > 0) { MessageBox.Show("添加成功"); }
                else { MessageBox.Show("添加失败"); }
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
            }
        }


        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            b1 = true; b2 = false; b3 = false;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            b1 = false; b2 = true; b3 = false;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            b1 = false; b2 = false; b3 = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (b1)
            {
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                a = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();


            }
            else if (b2)
            {
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                b = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else if (b3)
            {
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                c = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
    }
}
