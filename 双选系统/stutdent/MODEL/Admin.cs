﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Admin
    {
        private string uid;
       
        private string psd;
        
        private string pid;
       
        private string email;

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        public string Psd
        {
            get { return psd; }
            set { psd = value; }
        }

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Admin(string uid,string pid,string email)
        {
            this.uid = uid;
            this.pid = pid;
            this.email = email;
        }
    }
}
