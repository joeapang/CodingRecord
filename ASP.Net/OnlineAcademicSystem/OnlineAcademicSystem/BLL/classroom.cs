using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAcademicSystem.BLL
{
    public partial class classroom
    {
        private readonly OnlineAcademicSystem.DAL.classroom dal = new OnlineAcademicSystem.DAL.classroom();
        public classroom()
        { }
        //是否存在该记录
        public bool Exists(string classroom_id, out bool Result)
        {
            dal.Exists(classroom_id, out Result);
            return Result;
        }
        //添加教室
        public bool Add(OnlineAcademicSystem.Model.classroom model)
        {
            return dal.Add(model);
        }
         //删除教室
        public void Delete(string classroom_id)
        {
            dal.Delete(classroom_id);
        }
        //查询该教室是否被关联
        public bool Query_classroom(string classroom_id,out bool Result)
        {
            dal.Query_classroom(classroom_id,out Result);
            return Result;
        }
        //获取当前最大ID
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
