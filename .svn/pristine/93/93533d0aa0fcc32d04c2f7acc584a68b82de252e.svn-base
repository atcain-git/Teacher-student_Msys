using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Group
    {
        SQLDAL.Group dao = new SQLDAL.Group();
        public bool IsExistence(string uid,Model.Group group)
        {
            if (dao.IsExistence(uid,group))
            {
                return true;
            }
            return false;
        }
        public void InsertOrModefiy(string uid,int gid, Model.Group group, out string msg)
        {
            if (!dao.isCanDoit(uid))
            {
                msg = "你没有权限";
                return;
            }
            if (gid == 0)
            {
                dao.Insert(group);
                msg = "插入成功";
                return ;
            }
            dao.Excute(group);
            msg = "更改成功";
            return;
        }
        
    }
}
