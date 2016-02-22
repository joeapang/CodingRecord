using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAcademicSystem.BLL
{
    public partial class teacher_position
    {
        private readonly OnlineAcademicSystem.DAL.teacher_position dal = new OnlineAcademicSystem.DAL.teacher_position();
        public teacher_position()
        { }
        //是否存在该记录
        public bool Exists(string teacher_position_id, out bool Result)
        {
            dal.Exists(teacher_position_id, out Result);
            return Result;
        }
        //添加老师职称
        public bool Add(OnlineAcademicSystem.Model.teacher_position model)
        {
            return dal.Add(model);
        }
        //查询教师职称和教师是否有关联
        public bool Query(string teacher_position_id, out bool Result)
        {
            dal.Query(teacher_position_id,out Result);
            return Result;
        }
        //删除教师职称
        public void Delete(string teacher_position_id)
        {
            dal.Delete(teacher_position_id);
        }
        //获取当前最大ID
         public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
