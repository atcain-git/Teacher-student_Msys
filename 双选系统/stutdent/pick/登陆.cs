﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Model;
using BLL;
namespace pick
{
    public partial class 登陆 : Form
    {
        private string uid;
        BLL.Student studentLogic = new BLL.Student();
        public 登陆()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Model.Student student = new Model.Student()
            {
                    StuId = this.textBox1.Text.Trim(),
                    StuPsd = this.textBox2.Text.Trim()

            };
            Model.Student studentLogin = studentLogic.UserLogin(student);

            if (studentLogin == null)
            {
                MessageBox.Show("账号或密码错误，请重新输入");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                //MessageBox.Show("登陆成功");
                this.uid = student.StuId;
                学生 a = new 学生(this.uid);//新窗体弹窗，旧的隐藏
                this.Hide();
                a.ShowDialog();
                this.Show();


            }
        }

   

        private void 登陆_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 登陆_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           密码找回 a = new 密码找回();//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
