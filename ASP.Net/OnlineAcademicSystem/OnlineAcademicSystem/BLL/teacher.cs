using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class teacher
    {
        private readonly OnlineAcademicSystem.DAL.teacher dal = new OnlineAcademicSystem.DAL.teacher();
        public teacher()
        { }
        //是否存在该记录
        public bool Exists(string teacher_id,out bool Result)
        {
            dal.Exists(teacher_id,out Result);
            return Result;
        }
        //查询老师
        public DataTable Exists(string teacher_id)
        {
            return dal.Exists(teacher_id);
        }
        //教师登录
        public bool Login(string teacher_id, string teacher_password, out bool Result)
        {
            dal.Login(teacher_id, teacher_password, out Result);
            return Result;
        }
        //添加老师
        public bool Add(OnlineAcademicSystem.Model.teacher model)
        {
            return dal.Add(model);
        }
         //更新教师信息
        //更新教师信息
        public void Update_teacher(OnlineAcademicSystem.Model.teacher model,string teacher_id)
        {
            dal.Update_teacher(model, teacher_id);
        }
        //删除教师
        public void Delete(string teacher_id)
        {
            dal.Delete(teacher_id);
        }
         //修改密码
        public void Modifypassword(string teacher_id, string newpassword)
        {
            dal.Modifypassword(teacher_id,newpassword);
        }
    }
}
