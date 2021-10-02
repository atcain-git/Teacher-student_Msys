using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class Time
    {
        SQLDAL.Time t = new SQLDAL.Time();
        public bool modifyTime(Model.Time time,out string msg)
        {
            if (t.Update_time(time))
            {
                msg = "提交成功";
                return true;
            }
            else { msg = "提交失败"; return false; }
                
        }
    }
}
