using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using SQLDAL;
namespace BLL
{
    public class Message
    {
        SQLDAL.Message dao_mess = new SQLDAL.Message();
        public bool InsertMessage(Model.Message mess,out string msg)
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
        public void select_info(Model.Message mess)
        {
            dao_mess.slt_info(mess);

        }
    }
}
