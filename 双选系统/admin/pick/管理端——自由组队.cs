using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SQLDAL;

namespace pick
{
    public partial class 管理端__自由组队 : Form
    {
        public 管理端__自由组队()
        {
            InitializeComponent();
        }
        DataTable dt_g;
        DataTable dt_t;
        DataTable score;
        DataTable t_res;
        DataTable g_res;
        int res_count = 4;
        private void 管理端__自由组队_Load(object sender, EventArgs e)
        {
            
            //dataGridView3.DataSource = score;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView5.DataSource = t_res;

        }
        void count_score()
        {
            for (int i = 0; i < dt_g.Rows.Count; i++)
            {
                int gid = Convert.ToInt32(dt_g.Rows[i]["gid"]);

                for (int j = 0; j < dt_t.Rows.Count; j++)
                {
                    int tid = Convert.ToInt32(dt_t.Rows[j]["tid"]);

                    int[] S_c = { 0, 0, 0 };
                    int[] T_c = { 0, 0, 0, 0, 0 };

                    double marks_s = 0.0;
                    double marks_t = 0.0;

                    for (int n = 0; n < 3; n++)
                    {
                        int tmp_c = Convert.ToInt32(dt_g.Rows[i][n + 1]);
                        if (tmp_c == tid) S_c[n] = 1;

                        marks_s += Math.Pow(S_c[n] * 2, 3 - n);
                    }

                    for (int n = 0; n < 5; n++)
                    {
                        int tmp_c = Convert.ToInt32(dt_t.Rows[j][n + 1].Equals(DBNull.Value) ? 0 : dt_t.Rows[j][n + 1]);
                        if (tmp_c == gid) T_c[n] = 1;
                        marks_t += Math.Pow(T_c[n] * 2, 5 - n);
                    }

                    DataRow dr = score.NewRow();
                    dr["组ID"] = gid;
                    dr["老师ID"] = tid;
                    dr["S_c1"] = S_c[0];
                    dr["S_c2"] = S_c[1];
                    dr["S_c3"] = S_c[2];
                    dr["T_c1"] = T_c[0];
                    dr["T_c2"] = T_c[1];
                    dr["T_c3"] = T_c[2];
                    dr["T_c4"] = T_c[3];
                    dr["T_c5"] = T_c[4];
                    dr["得分"] = marks_s + marks_t * 1.1;
                    dr["del"] = 0;

                    score.Rows.Add(dr);
                }
            }

            //dataGridView3.DataSource = score;
        }
        void make_table()
        {
            score = new DataTable();
            score.Columns.Add("组ID", Type.GetType("System.Int32"));
            score.Columns.Add("老师ID", Type.GetType("System.Int32"));
            score.Columns.Add("S_c1", Type.GetType("System.Int32"));
            score.Columns.Add("S_c2", Type.GetType("System.Int32"));
            score.Columns.Add("S_c3", Type.GetType("System.Int32"));
            score.Columns.Add("T_c1", Type.GetType("System.Int32"));
            score.Columns.Add("T_c2", Type.GetType("System.Int32"));
            score.Columns.Add("T_c3", Type.GetType("System.Int32"));
            score.Columns.Add("T_c4", Type.GetType("System.Int32"));
            score.Columns.Add("T_c5", Type.GetType("System.Int32"));
            score.Columns.Add("得分", Type.GetType("System.Single"));
            score.Columns.Add("del", Type.GetType("System.Int32"));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from g";
            //string sql = "select * from g,student,groupp where g.gid = groupp.groupid and student.id = groupp.headman and student.grade = @grade and student.major = @major;";
            SqlParameter[] paras = new SqlParameter[]
             {     
                new SqlParameter ( "@grade",int.Parse(comboBox2.Text)),
                new SqlParameter ( "@major",comboBox1.Text.ToString()) 

             };
            dt_g = SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, paras);
            
            //dataGridView1.DataSource = dt_g;

            
            sql = "select * from t";
            dt_t = SqlDbHelper.ExecuteDataTable(sql);
            //dataGridView2.DataSource = dt_t;
            make_table();
            //dataGridView3.DataSource = score;
            count_score();
            DataView dataView = score.DefaultView;
            dataView.RowFilter = "得分>0";
            dataView.Sort = "得分 DESC";
            score = dataView.ToTable();
            t_res = dt_t.Copy();
            g_res = dt_g.Copy();
            DataRow dr; //遍历的每一行记录
            DataRow[] gids;//每行记录的队伍ID
            DataRow[] tids;//每行记录的老师ID
            DataRow[] g_tids;//老师选择的5个队伍的ID

            for (int i = 0; i < score.Rows.Count; i++)
            {
                dr = score.Rows[i];

                int tid, gid, mark, del, t_rescount;

                gid = Convert.ToInt32(dr["组ID"]);
                tid = Convert.ToInt32(dr["老师ID"]);
                mark = Convert.ToInt32(dr["得分"]);
                del = Convert.ToInt32(dr["del"]);
                t_rescount = Convert.ToInt32(t_res.Rows[tid - 1000]["res_count"]);
                //t_rescount = t_res.Select("tid=" + tid)[0].;
                if (del == 1)
                    continue;

                gids = score.Select("组ID=" + gid);

                tids = t_res.Select("tid=" + tid);

                for (int n = 0; n < 5; n++)
                {
                    if (t_rescount == res_count)
                        break;

                    int g_id = Convert.ToInt32(tids[0]["g" + (n + 1)]);
                    if (g_id == -1)
                    {
                        for (int j = 0; j < gids.Length; j++)
                            gids[j]["del"] = 1;
                        tids[0]["g" + (n + 1)] = gid;
                        tids[0]["res_count"] = t_rescount + 1;
                        g_tids = g_res.Select("gid=" + gid);
                        g_tids[0]["t"] = tid;
                        break;
                    }
                    else
                        continue;
                }
            }
            //dataGridView2.DataSource = g_res;
            DataTable data = new DataTable();
            foreach(DataRow row in g_res.Rows){
                BLL.Group g = new BLL.Group();
                data.Merge(g.getInfo((int)row["gid"], (string)row["t"]));
            }
            dataGridView2.DataSource = data;
            int width = 0;
            for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                this.dataGridView2.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //记录整个DataGridView的宽度
                width += this.dataGridView2.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > this.dataGridView1.Size.Width)
            {
                this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dataGridView2.Columns[1].Frozen = true;
            //内容居中
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (int.Parse(comboBox2.Text) == 2018 && comboBox1.Text.ToString().Equals("信息管理与信息系统"))
            {

            }
            else
            {
                MessageBox.Show("没有队伍");
            }
        }
    }
}
