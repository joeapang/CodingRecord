using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAcademicSystem.BLL
{
    public partial class grade
    {
        private readonly OnlineAcademicSystem.DAL.grade dal = new OnlineAcademicSystem.DAL.grade();
        public grade()
        { }
         //是否存在该记录
        public bool Exists(string grade_id, out bool Result)
        {
            dal.Exists(grade_id, out Result);
            return Result;
        }
        //添加年级
        public bool Add(OnlineAcademicSystem.Model.grade model)
        {
            return dal.Add(model);
        }
        //删除年级
        public void Delete(string grade_id)
        {
            dal.Delete(grade_id);
        }
         //查询年级和学生是否有关联
        public bool Query_grade_student(string grade_id, out bool Result)
        {
            dal.Query_grade_student(grade_id, out Result);
            return Result;
        }
        //查询年级和课程是否有关联
        public bool Query_grade_course(string grade_id, out bool Result)
        {
            dal.Query_grade_course(grade_id, out Result);
            return Result;
        }
         //查询年级和班级是否关联
        public bool Query_grade_classes(string grade_id, out bool Result)
        {
            dal.Query_grade_classes(grade_id, out Result);
            return Result;
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
