using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class student
    {
        private readonly OnlineAcademicSystem.DAL.student dal = new OnlineAcademicSystem.DAL.student();
        public student()
        { }
         //是否存在该记录
        public bool Exists(string student_id, out bool Result)
        {
            dal.Exists(student_id, out Result);
            return Result;
        }
        //查询学生
        public DataTable Exists(string student_id)
        {
            return dal.Exists(student_id);
        }
        //学生登录
        public bool Login(string student_id, string student_password, out bool Result)
        {
            dal.Login(student_id, student_password, out Result);
            return Result;
        }
        //添加学生
        public bool Add(OnlineAcademicSystem.Model.student model)
        {
            return dal.Add(model);
        }
        //学生信息粗略查询
        public DataTable Query_student_skim(string maior_id,string class_id)
        {
            return dal.Query_student_skim(maior_id, class_id);
        }
        //按学号查询学生
        public DataTable Query_student_id(string student_id)
        {
            return dal.Query_student_id(student_id);
        }
        //更新学生信息
        public void Update_student(OnlineAcademicSystem.Model.student model,string student_id)
        {
            dal.Update_student(model, student_id);
        }
        //删除学生
        public void Delete(string student_id)
        {
            dal.Delete(student_id);
        }
        //修改密码
        public void Modifypassword(string student_id, string newpassword)
        {
            dal.Modifypassword(student_id,newpassword);
        }
    }
}
