using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace pick
{
    public partial class 学生队伍管理 : Form
    {
        private string uid;

        public 学生队伍管理()
        {
            InitializeComponent();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        int index = 0;
        public 学生队伍管理(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void 学生队伍管理_Load(object sender, EventArgs e)
        {

            string grade = Grade.Text;
            string major = Major.Text;
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            if (!true)
            {
                dataGridView2.DataSource = b_group.getGroup(grade, major, uid);
            }
            else
            {
                dataGridView2.DataSource = b_group.getGroup(uid);
            }
            int width = 0;
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                //将每一列都调整为自动适应模式
                this.dataGridView2.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.ColumnHeader);
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
            printDocument1.PrintPage += new PrintPageEventHandler(printdoc_PrintPage);
        }
        int pageNo = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            index = 0;
            printPreviewDialog1.Document = printDocument1;

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();

            pageNo = 0;
            index = 0;
        }
        void printdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 150;
            int x = 100;
            pageNo++;
            Font f = new Font("宋体", 20);
            Font b = new Font("宋体", 20);
            Font c = new Font("黑体", 20);
            e.Graphics.DrawString(string.Format("{0}级{1}专业学生队伍", Grade.Text, Major.Text), c, Brushes.Black, 200, 10);
            e.Graphics.DrawString("组号", b, Brushes.Black, x + 5, y - 50);
            e.Graphics.DrawString("项目名称", b, Brushes.Black, x + 200, y - 50);
            e.Graphics.DrawString("项目介绍", b, Brushes.Black, x + 420, y - 50);

            Pen blackPen = new Pen(Color.Black, 3);

            for (; index < dataGridView2.Rows.Count; index++)
            {
                e.Graphics.DrawString(dataGridView2.Rows[index].Cells[0].Value.ToString(), f, Brushes.Black, x + 10, y);
                e.Graphics.DrawString(dataGridView2.Rows[index].Cells[1].Value.ToString(), f, Brushes.Black, x + 200, y);
                e.Graphics.DrawString(dataGridView2.Rows[index].Cells[2].Value.ToString(), f, Brushes.Black, x + 420, y);
                //e.Graphics.DrawString(dtInfo.Rows[index][3].ToString(), f, Brushes.Black, x + 320, y);
                //e.Graphics.DrawString(dtInfo.Rows[index][4].ToString(), f, Brushes.Black, x + 450, y);
                //e.Graphics.DrawString(dtInfo.Rows[index][5].ToString(), f, Brushes.Black, x + 550, y);
                //e.Graphics.DrawString(dtInfo.Rows[index][6].ToString(), f, Brushes.Black, x + 750, y);

                e.Graphics.DrawLine(blackPen, x, y + 70, x + 4 * x + 100, y + 70);
                y += 100;
                if (y > e.PageBounds.Height - 100)
                {
                    index++;
                    e.HasMorePages = true;

                    break;


                }
                e.Graphics.DrawString(string.Format("第{0}页", pageNo), f, Brushes.Black, x + 6 * x, e.PageBounds.Height - 100);
                //e.Graphics.DrawString(string.Format("打印人{0}", pageNo), f, Brushes.Black, x + 5 * x, e.PageBounds.Height - 50);
            }

            if (index >= dataGridView2.Rows.Count)
            {
                pageNo = 0;
                index = 0;
            }


        }

        private void bt3_Click(object sender, EventArgs e)
        {
            string id = uid;
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            string msg = "";
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string _selectValue = dataGridView2.Rows[i].Cells["是否删除该队"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        /*
                        m_group.Gid = int.Parse(dataGridView2.Rows[i].Cells["小组编号"].ToString());
                        m_group.Pro_name = dataGridView2.Rows[i].Cells["项目名称"].ToString();
                        m_group.Hid_name = dataGridView2.Rows[i].Cells["队长"].ToString();
                        m_group.Mid1_name = dataGridView2.Rows[i].Cells["队员"].ToString();
                        m_group.Mid2_name = dataGridView2.Rows[i].Cells["队员1"].ToString();
                        m_group.Mid3_name = dataGridView2.Rows[i].Cells["队员2"].ToString();
                        m_group.First = dataGridView2.Rows[i].Cells["第一志愿"].ToString();
                        m_group.First = dataGridView2.Rows[i].Cells["第二志愿"].ToString();
                        m_group.First = dataGridView2.Rows[i].Cells["第三志愿"].ToString();
                        b_group.UpdateTea(m_group.Gid,m_group,out msg);
                         * */
                        string str = dataGridView2.Rows[i].Cells["组号"].EditedFormattedValue.ToString();
                        int gid = int.Parse(str);
                        int tmp = i+1;
                        try
                        {
                            b_group.del(gid,id,tmp,out msg);
                            MessageBox.Show(msg);
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("更改失败" + ex.Message);
                        }

                    }
                }
            }
        }
    }
}
