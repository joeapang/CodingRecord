using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class choose_course
    {
        private readonly OnlineAcademicSystem.DAL.choose_course dal = new OnlineAcademicSystem.DAL.choose_course();
        public choose_course()
        { }
        //是否存在该记录
        public bool Exists(string student_id, string course_id, out bool Result)
        {
            dal.Exists(student_id, course_id, out Result);
            return Result;
        }
        //添加选课
        public bool Add(OnlineAcademicSystem.Model.choose_course model)
        {
            return dal.Add(model);
        }
        //查询课程
        public DataTable Query(string major_id,string grade_id,string course_type_id)
        {
           return  dal.Query(major_id, grade_id, course_type_id);
        }
        //删除选课
        public void Delete(string student_id,string course_id)
        {
            dal.Delete(student_id, course_id);
        }
        //查询已选课程
        public DataTable Query_Choose(string student_id)
        {
            return dal.Query_Choose(student_id);
        }
        //学生课程是否存在关联
        public bool Exists(string student_id, out bool Result)
        {
            dal.Exists(student_id, out Result);
            return Result;
        }
        //查询某课程是否被选
        public bool Query_choose_course(string course_id,out bool Result)
        {
            dal.Query_choose_course(course_id, out Result);
            return Result;
        }
    }
}
