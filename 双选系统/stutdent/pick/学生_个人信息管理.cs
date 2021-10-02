﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pick
{
    public partial class 学生_个人信息管理 : Form
    {
        public 学生_个人信息管理()
        {
            InitializeComponent();
            
        }
        private string uid;
        public 学生_个人信息管理(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Model.Message message = new Model.Message();
            message.Name = sName.Text; message.Id = label5.Text;
            message.Sex = Sex.Text; message.Phone = Phone.Text;
            message.Major = Major.Text; message.Grade = Grade.Text;
            message.Email = Email.Text; message.College = College.Text;
            message.Class = Class.Text; message.Introduction = Intro.Text;
            BLL.Message b_mess = new BLL.Message();
            string msg = "";
            if (b_mess.InsertMessage(message, out msg))
            {
                MessageBox.Show(msg);
            }
        }

        private void 学生_个人信息管理_Load(object sender, EventArgs e)
        {
            string str = this.uid;
            label5.Text = str;
            sName.Enabled = false;
            Sex.Enabled = false;
            College.Enabled = false;
            Grade.Enabled = false;
            Class.Enabled = false;
            Major.Enabled = false;
            if (str != null || !str.Equals(""))
            {
                BLL.Message b_mess = new BLL.Message();
                Model.Message message = new Model.Message();
                message.Id = str;
                b_mess.select_info(message);
                sName.Text = message.Name;
                Sex.Text = message.Sex; Phone.Text = message.Phone;
                Major.Text = message.Major; Grade.Text = message.Grade;
                Email.Text = message.Email; College.Text = message.College;
                Class.Text = message.Class; Intro.Text = message.Introduction;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            学生 a = new 学生(uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
    }
}
