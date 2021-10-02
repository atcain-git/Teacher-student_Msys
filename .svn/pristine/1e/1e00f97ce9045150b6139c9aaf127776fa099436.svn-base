using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pick
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            登陆 b = new 登陆();
            DialogResult result = b.ShowDialog();
            if (result == DialogResult.OK)
                Application.Run(new 学生()); 

            //Application.Run(new 学生_个人组队管理());
            //Application.Run(new 选择导师());
            //Application.Run(new 登陆());
            //Application.Run(new 学生_个人信息管理());
            //Application.Run(new 学生());
            

        }
    }
}
