﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL;

namespace pick
{
    public partial class 教师_个人信息1 : Form
    {
        private string uid;
        public 教师_个人信息1()
        {
            InitializeComponent();
        }

        public 教师_个人信息1(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void 教师_个人信息1_Load(object sender, EventArgs e)
        {
            string str = uid;
            label5.Text = str;
            Sex.Enabled = false;
            Grade.Enabled = false;
            Major.Enabled = false;
            College.Enabled = false;
            Guidance.Enabled = false;
            Number.Enabled = false;
            Title.Enabled = false; 
            if (!str.Equals(""))
            {
                BLL.Message b_mess = new BLL.Message();
                MODEL.Message message = new MODEL.Message();
                message.Id = str;
                b_mess.select_info(message);
                sName.Text = message.Name;
                Sex.Text = message.Sex; Phone.Text = message.Phone;
                Major.Text = message.Major; Grade.Text = message.Grade;
                Email.Text = message.Email; College.Text = message.College;
                Number.Text = message.Number.ToString(); Title.Text = message.Title;
                pwd.Text = message.Psd; Guidance.Text = message.Gudiance;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MODEL.Message message = new MODEL.Message();
            message.Name = sName.Text; message.Id = label5.Text;
            message.Sex = Sex.Text; message.Phone = Phone.Text;
            message.Major = Major.Text; message.Grade = Grade.Text;
            message.Email = Email.Text; message.College = College.Text;
            message.Number = int.Parse(Number.Text.ToString()); message.Gudiance = Guidance.Text;
            message.Psd = pwd.Text; message.Title = Title.Text;
            BLL.Message b_mess = new BLL.Message();
            string msg = "";
            if (b_mess.InsertMessage(message, out msg))
            {
                MessageBox.Show(msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            教师 a = new 教师(uid);//新窗体弹窗，旧的隐藏
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
