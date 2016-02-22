using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAcademicSystem.BLL
{
    public partial class major
    {
        private readonly OnlineAcademicSystem.DAL.major dal = new OnlineAcademicSystem.DAL.major();
        public major()
        { }
         //是否存在该记录
        public bool Exists(string major_id, out bool Result)
        {
            dal.Exists(major_id, out Result);
            return Result;
        }
        //添加专业
        public bool Add(OnlineAcademicSystem.Model.major model)
        {
            return dal.Add(model);
        }
         //查询专业和班级是否有关联
        public bool Query_major_classes(string major_id,out bool Result)
        {
            dal.Query_major_classes(major_id, out Result);
            return Result;
        }
        //查询专业和课程是否有关联
        public bool Query_major_course(string major_id, out bool Result)
        {
            dal.Query_major_course(major_id, out Result);
            return Result;
        }
         //查询专业和老师是否有关联
        public bool Query_major_teacher(string major_id, out bool Result)
        {
            dal.Query_major_teacher(major_id, out Result);
            return Result;
        }
        //查询专业和学生是否有关联
        public bool Query_major_student(string major_id, out bool Result)
        {
            dal.Query_major_student(major_id, out Result);
            return Result;
        }
        //删除专业
        public void Delete(string major_id)
        {
            dal.Delete(major_id);
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
