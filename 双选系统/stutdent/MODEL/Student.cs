﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Student
    {
        private string _uid;
        private string _psd;
        public Student()
        {

        }
        
        public string StuId
        {
            set { _uid = value; }
            get { return this._uid; }
        }
        public string StuPsd
        {
            set { _psd = value; }
            get { return this._psd; }
        }
    }

}
