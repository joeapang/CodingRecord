using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class course
    {
        private readonly OnlineAcademicSystem.DAL.course dal = new OnlineAcademicSystem.DAL.course();
        public course()
        { }
         //是否存在该记录
        public bool Exists(string course_id, out bool Result)
        {
            dal.Exists(course_id, out Result);
            return Result;
        }
        //添加课程
        public bool Add(OnlineAcademicSystem.Model.course model)
        {
            return dal.Add(model);
        }
        //学生查看课表
        public DataTable Query_courselist(string student_id)
        {
            return dal.Query_courselist(student_id);
        }
        //查询课程
        public DataTable Query_course(string course_id)
        {
            return dal.Query_course(course_id);
        }
        //更新课程信息
        public void Update_course(OnlineAcademicSystem.Model.course model,string course_id)
        {
            dal.Update_course(model, course_id);
        }
        //删除课程
        public void Delete_course(string course_id)
        {
            dal.Delete_course(course_id);
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
