using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class course_type
    {
        private readonly OnlineAcademicSystem.DAL.course_type dal = new OnlineAcademicSystem.DAL.course_type();
        public course_type()
        { }
        //是否存在该记录
        public bool Exists(string course_type_id, out bool Result)
        {
            dal.Exists(course_type_id, out Result);
            return Result;
        }
        //添加课程类型
        public bool Add(OnlineAcademicSystem.Model.course_type model)
        {
            return dal.Add(model);
        }
        //查询课程类型和课程是否有关联
        public bool Query(string course_type_id,out bool Result)
        {
            dal.Query(course_type_id,out Result);
            return Result;
        }
         //删除课程类型
        public void Delete(string course_type_id)
        {
            dal.Delete(course_type_id);
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
