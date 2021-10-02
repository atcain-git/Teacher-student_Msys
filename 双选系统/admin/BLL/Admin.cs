﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Net;
using Model;
using SQLDAL;


namespace BLL
{
    public class Admin
    {
        public SQLDAL.Admin admin = new SQLDAL.Admin();
        public bool getPassword(Model.Admin ad, out string msg)
        {
            string psd = "";
            if (admin.isExistence(ad, out psd))
            {
                if (SendEmail("coinchuengidv@163.com", ad.Email, "zjy8200.", null, null, psd))
                {
                    msg = "密码发送成功";
                }
                else { msg = "密码发送失败"; }
                return true;
            }
            else { msg = "您的信息错误"; }
            return false;
        }
        public bool SendEmail(string FromMial, string ToMial, string AuthorizationCode, string ReplyTo, string CCMial, string File_Path)
        {
            MailMessage mail = new MailMessage(FromMial, ToMial, "发送邮件测试", "密码是" + File_Path);

            SmtpClient smtp = new SmtpClient();

            smtp.UseDefaultCredentials = false;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.EnableSsl = true;

            smtp.Host = "smtp.163.com";

            smtp.Port = 25;//I tried 465 as well

            smtp.Credentials = new NetworkCredential(FromMial, "HDAIMXRQMKAFMYGP");

            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
            
            //管理员业务逻辑类
        

        }
    public class AdminLogic
    {
        AdminDao adminDao = new AdminDao(); 

        public Model.AAdmin UserLogin(Model.AAdmin admin)
        {

            return adminDao.UserLogin(admin);
        }

    }
    }

