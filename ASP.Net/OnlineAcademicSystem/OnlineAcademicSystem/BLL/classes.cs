using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class classes
    {
        private readonly OnlineAcademicSystem.DAL.classes dal = new OnlineAcademicSystem.DAL.classes();
        public classes()
        { }
        //是否存在该记录
        public bool Exists(string class_id, out bool Result)
        {
            dal.Exists(class_id, out Result);
            return Result;
        }
        //添加班级
        public bool Add(OnlineAcademicSystem.Model.classes model)
        {
            return dal.Add(model);
        }
         //查询班级
        public DataTable Query_classes(string class_id)
        {
            return dal.Query_classes(class_id);
        }
        //更新班级
        public void Update_classes(OnlineAcademicSystem.Model.classes model,string class_id)
        {
            dal.Update_classes(model,class_id);
        }
         //删除班级
        public void Delete_classes(string class_id)
        {
            dal.Delete_classes(class_id);
        }
        //查询班级是否有学生
        public bool Query_classes_student(string class_id,out bool Result)
        {
            dal.Query_classes_student(class_id, out Result);
            return Result;
        }
    }
}
