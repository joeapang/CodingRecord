using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineAcademicSystem.BLL
{
    public partial class announcement
    {
        private readonly OnlineAcademicSystem.DAL.announcement dal = new OnlineAcademicSystem.DAL.announcement();
        public announcement()
        { }
         //是否存在附件
        public DataTable Exsit(int announcement_id)
        {
            return dal.Exsit(announcement_id);
        }
        //添加公告
        public void Add(OnlineAcademicSystem.Model.announcement model)
        {
            dal.Add(model);
        }
         //查看公告
        public DataTable Query_announcement(string announcement_id)
        {
            return dal.Query_announcement(announcement_id);
        }
         //获取当前最大ID
        public int GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}
