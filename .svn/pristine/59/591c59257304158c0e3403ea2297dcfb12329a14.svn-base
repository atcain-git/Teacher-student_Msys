using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MODEL;
using BLL;
using SQLDAL;
namespace pick
{
    public partial class 登陆 : Form
    {
        TeacherLogic teacherLogic = new TeacherLogic();
        private string uid;
        public 登陆()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODEL.Teacher teacher = new MODEL.Teacher()
            {
                UserId = this.textBox1.Text.Trim(),
                Password = this.textBox2.Text.Trim()

            };
            MODEL.Teacher teacherLogin = teacherLogic.UserLogin(teacher); 
            if (teacherLogin == null)
            {
                MessageBox.Show("账号或密码错误，请重新输入");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                //MessageBox.Show("登陆成功");
                this.uid = teacher.UserId;
               教师 a = new 教师(uid);//新窗体弹窗，旧的隐藏
                this.Hide();
                a.ShowDialog();
                this.Show();


            }
        }

        private void 登陆_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 登陆_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            密码找回 a = new 密码找回();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }





    }
}
