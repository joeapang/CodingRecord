using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAcademicSystem.BLL
{
    public partial class admin
    {
        private readonly OnlineAcademicSystem.DAL.admin dal = new OnlineAcademicSystem.DAL.admin();
        public admin()
        { }
        //管理员登录
        public bool Login(string admin_id, string admin_password,out bool Result)
        {
            dal.Login(admin_id, admin_password, out Result);
            return Result;
        }
        //添加管理员
        public bool Add(OnlineAcademicSystem.Model.admin model)
        {
            return dal.Add(model);
        }
        //修改密码
        public void Modifypassword(string admin_id,string newpassword)
        {
            dal.Modifypassword(admin_id, newpassword);
        }
    }
}
