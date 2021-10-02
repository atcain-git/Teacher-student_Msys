using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SQLDAL
{
    public class Utils
    {
        public static string getConnection()
        {
            Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath + "\\.. " + "\\.." + "\\.."+"\\..");
            string path = Directory.GetCurrentDirectory();
            string text = System.IO.File.ReadAllText(@path + "\\encrypt.txt");
            string[] info = AESUtils.AESDecrypt(text).Split(new string[] { "\r\n" }, StringSplitOptions.None);

            string  user = info[0];
            string psw = info[1];
            string connect_str = String.Format("server=121.5.51.167;database=homework;uid={0};pwd={1}",user,psw);
            return connect_str;
        } 
    }
}
