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
    public partial class 教师 : Form
    {
        private string uid;
        public 教师()
        {
            InitializeComponent();
        }
        public 教师(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void 教师_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            教师_个人信息1 a = new 教师_个人信息1(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            学生队伍管理 a = new 学生队伍管理(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            处理学生申请 a = new 处理学生申请(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            密码找回 a = new 密码找回();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登陆 a = new 登陆();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            密码找回 a = new 密码找回();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 学生队伍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生队伍管理 a = new 学生队伍管理(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 处理学生申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            处理学生申请 a = new 处理学生申请(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            教师_个人信息1 a = new 教师_个人信息1(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
