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
    public partial class 学生 : Form
    {
        private string uid;
        public 学生()
        {
            InitializeComponent();
        }
        public 学生(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void 学生个人信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生_分配结果情况 a = new 学生_分配结果情况(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

      

        private void 学生_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            学生_个人信息管理 a = new 学生_个人信息管理(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            学生_个人组队管理 a = new 学生_个人组队管理(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            选择导师 a = new 选择导师(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            学生_分配结果情况 a = new 学生_分配结果情况(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            密码找回 a = new 密码找回(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 退出登录ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            登陆 a = new 登陆();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 选择导师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            选择导师 a = new 选择导师(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 个人信息填写ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生_个人信息管理 a = new 学生_个人信息管理(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 修改密码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            密码找回 a = new 密码找回(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 学生_FormClosed(object sender, FormClosedEventArgs e)
        {
           登陆 a = new 登陆();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
