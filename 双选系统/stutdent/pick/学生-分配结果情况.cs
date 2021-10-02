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
    public partial class 学生_分配结果情况 : Form
    {
        public 学生_分配结果情况()
        {
            InitializeComponent();
        }
        private string uid;
        public 学生_分配结果情况(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            学生 a = new 学生 (uid);//新窗体弹窗，旧的隐藏
            this.Hide();
            this.Close();
            a.ShowDialog();
            this.Show();
        }
    }
}
