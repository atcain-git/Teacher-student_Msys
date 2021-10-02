﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pick
{
    public partial class 处理学生申请 : Form
    {
        private string uid;
        public 处理学生申请()
        {
            InitializeComponent();
        }
        public 处理学生申请(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void 处理学生申请_Load(object sender, EventArgs e)
        {
            string grade = Grade.Text;
            string major = Major.Text;
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            dataGridView2.DataSource = b_group.getGroups(grade,major,uid);
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

        private void button7_Click(object sender, EventArgs e)
        {
            string id = uid;
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            string msg = "";
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string _selectValue = dataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn5"].EditedFormattedValue.ToString();
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
                        string str = dataGridView2.Rows[i].Cells["小组编号"].EditedFormattedValue.ToString();
                        int gid = int.Parse(str);
                        try
                        {
                            b_group.UpdateTea(gid, id,out msg);
                            MessageBox.Show(msg);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("更改失败" + ex.ErrorCode);
                        }
                        catch(Exception ex){
                            MessageBox.Show("更改失败" + ex.Message);
                        }
                        
                    }
                }
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string grade = Grade.Text;
            string major = Major.Text;
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            dataGridView2.DataSource = b_group.getGroups(grade, major,uid);
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
    }
}
