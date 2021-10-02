using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pick
{
    public partial class 管理员_未组队学生管理 : Form
    {
        public 管理员_未组队学生管理()
        {
            InitializeComponent();
        }
        int pageSize = 10;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataSet ds = new DataSet();
        DataTable dtInfo = new DataTable();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void 管理员_未组队学生管理_Load(object sender, EventArgs e)
        {
            BLL.Student b_student = new BLL.Student();
            string grade = Grade.Text;
            string major = Major.Text;
            DataTable dt = b_student.getUnOrgnizeEnity(grade, major);
            dataGridView2.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                //MessageBox.Show("当前没有学生");
                return;
            }
            bs.DataSource = dt;
            dtInfo = dt.Copy();
            InitDataSet();
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
            if (width > this.dataGridView2.Size.Width)
             {
                 this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
             }
             else
             {
                 this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             }
             //冻结某列 从左开始 0，1，2
            dataGridView2.Columns[1].Frozen = true;
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string grade = Grade.Text;
            string major = Major.Text;
            BLL.Student b_student = new BLL.Student();
            DataTable dt = null;
         
            dt = b_student.getUnOrgnizeEnity(grade, major);
            dataGridView2.DataSource = dt;
           

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("当前没有学生");
                return;
            }
            bs.DataSource = dt;
            dtInfo = dt.Copy();
            InitDataSet();
        }
        void InitDataSet()
        {
            pageSize = 10;      //设置页面行数
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
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nStartPos++;
            }
            bindingSource1.DataSource = dtTemp;
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView2.DataSource = bindingSource1;
            bindingNavigatorCountItem.Text = pageCount.ToString();
            bindingNavigatorPositionItem.Text = Convert.ToString(pageCurrent);
        }
        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bs;
            dataGridView2.DataSource = bs;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
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

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.bs.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.bs.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.bs.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.bs.MoveLast();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
