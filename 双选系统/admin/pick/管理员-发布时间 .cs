﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace pick
{
    public partial class 发布时间 : Form
    {
        public 发布时间()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Time time = new Model.Time();
            time.D1 = d1.Value;
            time.D2 = d2.Value;
            time.D3 = d3.Value;
            time.D4 = d4.Value;
            BLL.Time b_time = new BLL.Time();
            string msg = "";
            if (b_time.modifyTime(time,out msg ))
            {               //MessageBox.Show(msg);   
            }
            MessageBox.Show(msg);
        }

    }
}
