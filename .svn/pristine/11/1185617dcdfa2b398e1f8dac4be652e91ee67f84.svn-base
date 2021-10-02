using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SQLDAL;
using Model;
using BLL;
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
            if (result== DialogResult.OK)
            Application.Run(new 管理员()); 
            
           

            //Application.Run(new 教师信息管理());
            //Application.Run(new 组队情况管理());C:\Users\冯小萍\Desktop\新建文件夹\admin\pick\Program.cs
            //Application.Run(new 登陆());
            //Application.Run(new 密码找回());
            //Application.Run(new 学生信息管理());

        }
    }
}
