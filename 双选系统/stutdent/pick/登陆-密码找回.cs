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
    public partial class 密码找回 : Form
    {
        public 密码找回()
        {
            InitializeComponent();
        }
        private string uid;
        public 密码找回(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void 密码找回_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uid = textBox1.Text;
            string pid = textBox5.Text;
            string email = textBox2.Text;
            BLL.Admin admin = new BLL.Admin();
            Model.Admin data = new Model.Admin(uid, pid, email);
            string msg = "";
            if (admin.getPassword(data, out msg))
            {
                //MessageBox.Show(msg);
            }
            MessageBox.Show(msg);
        }

    }
}
