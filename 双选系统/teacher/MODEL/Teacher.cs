﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class Teacher
    {
        public Teacher()
        {

        }
        private string _userId;
        private string _password;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId
        {
            set { _userId = value; }
            get { return _userId; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
    }
    
}
