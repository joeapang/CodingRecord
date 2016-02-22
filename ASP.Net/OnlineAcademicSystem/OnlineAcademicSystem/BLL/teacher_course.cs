using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class teacher_course
    {
        private readonly OnlineAcademicSystem.DAL.teacher_course dal = new OnlineAcademicSystem.DAL.teacher_course();
        public teacher_course()
        { }
        //添加老师课程
        public bool Add(OnlineAcademicSystem.Model.teacher_course model)
        {
            return dal.Add(model);
        }
        //老师查看授课
        public DataTable Query_course(string teacher_id)
        {
            return dal.Query_course(teacher_id);
        }
        //老师课程是否存在关联
        public bool Exists(string teacher_id, out bool Result)
        {
            dal.Exists(teacher_id, out Result);
            return Result;
        }
        //删除更新教师课程关联
        public void Delete(string teacher_id,string course_id)
        {
            dal.Delete(teacher_id, course_id);
        }
        //删除某课程和老师的全部关联
        public void Delete_teacher_course(string course_id)
        {
            dal.Delete_teacher_course(course_id);
        }
    }
}
