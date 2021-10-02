﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using SQLDAL;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace pick
{
    public partial class 学生信息管理 : Form
    {
        int index = 0;
        public 学生信息管理()
        {
            InitializeComponent();
        }
        string con = SQLDAL.SqlDbHelper.ConnectionString;
        int pageSize = 10;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 1;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataSet ds = new DataSet();
        DataTable dtInfo = new DataTable();  
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        void InitDataSet()
        {
            //pageSize = 10;      //设置页面行数
            nMax = dtInfo.Rows.Count;
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0)
                pageCount++;
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData();
        }
        void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架
            if (pageCurrent == pageCount)
            {
                nEndPos = nMax;
            }
            else
            {
                nEndPos = pageSize * pageCurrent;
            }

            nStartPos = nCurrent;
            //MessageBox.Show(bindingNavigatorCountItem.Text);


            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            bindingSource1.DataSource = dtTemp;
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            //this.bnci.Text = "/" + pageCount.ToString();
            //this.bnpi.Text = Convert.ToString(pageCurrent);
            bindingNavigatorCountItem.Text = pageCount.ToString();
            bindingNavigatorPositionItem.Text = Convert.ToString(pageCurrent);
        }

        private void 学生信息管理_Load(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = true;//纸张横向
            printDocument1.DefaultPageSettings.Landscape = true;

            string grade = Grade.Text;
            string major = Major.Text;
            BLL.Student b_student = new BLL.Student();
            DataTable dt = b_student.getEnitity(grade,major,"","");
            dataGridView1.DataSource = dt;
            bs.DataSource = dt;
            dtInfo = dt.Copy();
            InitDataSet();
            /*int width = 0;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                this.dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //记录整个DataGridView的宽度
                width += this.dataGridView1.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > this.dataGridView1.Size.Width)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dataGridView1.Columns[1].Frozen = true;
            //内容居中
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             */
            printDocument1.PrintPage += new PrintPageEventHandler(printdoc_PrintPage);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            
        }
        private void insertToSql_stu(DataRow dr)
        {
            try
            {
                string password = dr["密码"].ToString().Equals("") ? "" : dr["密码"].ToString();
                string name = dr["姓名"].ToString().Equals("") ? "" : dr["姓名"].ToString();
                string sex = dr["性别"].ToString().Equals("") ? "" : dr["性别"].ToString();
                string id = dr["学号"].ToString().Equals("") ? "" : dr["学号"].ToString();
                string grade = dr["年级"].ToString().Equals("") ? "" : dr["年级"].ToString();
                string major = dr["专业"].ToString().Equals("") ? "" : dr["专业"].ToString();
                string Class = dr["班别"].ToString().Equals("") ? "" : dr["班别"].ToString();
                string phone = dr["电话号码"].ToString().Equals("") ? "" : dr["电话号码"].ToString();
                string email = dr["邮箱地址"].ToString().Equals("") ? "" : dr["邮箱地址"].ToString();
                string introduce = dr["自我介绍"].ToString().Equals("") ? "" : dr["自我介绍"].ToString();
                string college = dr["学院"].ToString().Equals("") ? "" : dr["学院"].ToString();
                //string groupID = dr["团队编号"].ToString();
                SqlDbHelper.ExecuteNonQuery(string.Format("insert into student(id,psw,name,sex,college,grade,email,phone,major,introduction,class) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", id, password, name, sex, college, grade, email, phone, major, introduce, Class));
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void exceldata_stu()
        {
            System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "EXCEL文件|*.xlsx|所有文件|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileName = fd.FileName;
                bind_stu(fileName);
                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    
                    try{    
                        insertToSql_stu(dr);
                        MessageBox.Show("导入成功");

                    }catch(Exception e){
                        MessageBox.Show("导入失败");
                    }
                    
                }
                
                
            }
        }
        //方法二，利用委托机制实现线程安全;
        private delegate void DelegateDataGridViewWRLUI();
        //打开Excel，把数据放进dataGridView中
        private void bind_stu(string fileName)
        {
            DelegateDataGridViewWRLUI delegateDataGridViewWRLUI = delegate
            {
                //取消跨线程检查，不使用委托的方法，解决“线程间操作无效，从不是创建控件的线程访问它”的问题
                //进行非安全线程访问时，运行环境就不去检验它是否是线程安全的
                //Control.CheckForIllegalCrossThreadCalls = false;//方法一，不建议，转 利用委托机制实现线程安全。

                //office2007版本以上
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'";
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT *  FROM [sheet1$]", strConn);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                    dt = ds.Tables[0];

                }
                catch (Exception err)
                {
                    MessageBox.Show("操作失败！" + err.ToString());
                }
                //textBox1.Text = "" + fileName;
            };
            this.dataGridView1.Invoke(delegateDataGridViewWRLUI);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string grade = Grade.Text;
            string major = Major.Text;
            string del = comboBox1.Text;
            string value = textBox1.Text;
            BLL.Student b_student = new BLL.Student();
            DataTable dt = null;
            try
            {
                dt = b_student.getEnitity(grade, major, del, value);
                dataGridView1.DataSource = dt;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("当前没有学生");
            }catch(Exception ex){
                MessageBox.Show("操作失败");
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("当前没有学生");
                return;
            }
            bs.DataSource = dt;
            dtInfo = dt.Copy();
            InitDataSet();
            int width = 0;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                this.dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //记录整个DataGridView的宽度
                width += this.dataGridView1.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > this.dataGridView1.Size.Width)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dataGridView1.Columns[1].Frozen = true;
            //内容居中
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }



        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //this.bs.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            //this.bs.MoveFirst();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //this.bs.MovePrevious();
            if (pageCurrent >= 0)
            {
                pageCurrent--;
            }
            if (pageCurrent <= 0)
            {
                pageCurrent++;
                MessageBox.Show("已经是第一页");
                return;
            }
            else
            {
                nCurrent = pageSize * (pageCurrent - 1);
            }

            LoadData();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            //this.bs.MoveNext();
            pageCurrent++;
            if (pageCurrent > pageCount)
            {
                MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                return;
            }
            else
            {
                nCurrent = pageSize * (pageCurrent - 1);
            }
            LoadData();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
           // bs.DataSource = dataGridView1;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
        }
        void insert()
        {
            string con = SQLDAL.SqlDbHelper.ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("insert into student() values ()", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
           dataGridView1.DataSource = ds;
           da.Update(ds);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (pageCurrent >= 0)
            {
                pageCurrent--;
            }
            if (pageCurrent <= 0)
            {
                pageCurrent++;
                MessageBox.Show("已经是第一页");
                return;
            }
            else
            {
                nCurrent = pageSize * (pageCurrent - 1);
            }

            LoadData();
        }


        int pageNo = 0;
        void printdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 150;
            int x = 100;
            pageNo++;
            Font f = new Font("宋体", 10);
            Font b = new Font("宋体", 10);
            Font c = new Font("黑体", 20);
            e.Graphics.DrawString(string.Format("{0}级{1}专业学生信息", Grade.Text, Major.Text), c, Brushes.Black, 240, 10);
            e.Graphics.DrawString("学号", b, Brushes.Black, x + 5, y - 50);
            e.Graphics.DrawString("姓名", b, Brushes.Black, x + 100, y - 50);
            e.Graphics.DrawString("年级", b, Brushes.Black, x + 220, y - 50);
            e.Graphics.DrawString("性别", b, Brushes.Black, x + 320, y - 50);
            e.Graphics.DrawString("学院", b, Brushes.Black, x + 450, y - 50);
            e.Graphics.DrawString("专业", b, Brushes.Black, x + 550, y - 50);
            e.Graphics.DrawString("联系电话", b, Brushes.Black, x + 750, y - 50);
            e.Graphics.DrawString("密码", b, Brushes.Black, x + 850, y - 50);
            Pen blackPen = new Pen(Color.Black, 3);

            for (; index < dtInfo.Rows.Count; index++)
            {
                e.Graphics.DrawString(dtInfo.Rows[index][0].ToString(), f, Brushes.Black, x + 10, y);
                e.Graphics.DrawString(dtInfo.Rows[index][1].ToString(), f, Brushes.Black, x + 100, y);
                e.Graphics.DrawString(dtInfo.Rows[index][2].ToString(), f, Brushes.Black, x + 220, y);
                e.Graphics.DrawString(dtInfo.Rows[index][3].ToString(), f, Brushes.Black, x + 320, y);
                e.Graphics.DrawString(dtInfo.Rows[index][4].ToString(), f, Brushes.Black, x + 450, y);
                e.Graphics.DrawString(dtInfo.Rows[index][5].ToString(), f, Brushes.Black, x + 550, y);
                e.Graphics.DrawString(dtInfo.Rows[index][6].ToString(), f, Brushes.Black, x + 750, y);
                e.Graphics.DrawString(dtInfo.Rows[index][7].ToString(), f, Brushes.Black, x + 850, y);


                e.Graphics.DrawLine(blackPen, x, y + 70, x + 4 * x + 500, y + 70);
                y += 100;
                if (y > e.PageBounds.Height - 100)
                {
                    index++;
                    e.HasMorePages = true;

                    break;


                }
                e.Graphics.DrawString(string.Format("第{0}页", pageNo), f, Brushes.Black, x + 8 * x, e.PageBounds.Height - 50);
                //e.Graphics.DrawString(string.Format("打印人{0}", pageNo), f, Brushes.Black, x + 5 * x, e.PageBounds.Height - 50);
            }

            if (index >= dtInfo.Rows.Count)
            {
                pageNo = 0;
                index = 0;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            index = 0;
            printPreviewDialog1.Document = printDocument1;

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();

            pageNo = 0;
            index = 0;
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            if (pageCurrent >= 0)
            {
                pageCurrent--;
            }
            if (pageCurrent <= 0)
            {
                pageCurrent++;
                MessageBox.Show("已经是第一页");
                return;
            }
            else
            {
                nCurrent = pageSize * (pageCurrent - 1);
            }

            LoadData();
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            pageCurrent++;
            if (pageCurrent > pageCount)
            {
                MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                return;
            }
            else
            {
                nCurrent = pageSize * (pageCurrent - 1);
            }
            LoadData();
        }

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(exceldata_stu));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        
        }

        

           
    
        
    }

