using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Message
    {
        SQLDAL.Message dao_mess = new SQLDAL.Message();
        public bool InsertMessage(MODEL.Message mess, out string msg)
        {
            if (dao_mess.insert(mess))
            {
                msg = "更改成功";
            }
            else
            {
                msg = "更改失败";
            }
            return true;
        }
        public void select_info(MODEL.Message mess)
        {
            dao_mess.slt_info(mess);

        }
    }
}
