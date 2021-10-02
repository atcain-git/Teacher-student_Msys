using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDAL;

namespace BLL
{
    public class Group
    {
        SQLDAL.Group dao = new SQLDAL.Group();
        public DataTable getInfo(int gid, string tid)
        {
            return dao.getGroupInfo(gid, tid);
        }
    }
}
