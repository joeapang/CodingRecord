using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// choose_course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class choose_course
	{
		public choose_course()
		{}
		#region Model
		private string _student_id;
		private string _course_id;
        private int _course_score;
		/// <summary>
		/// 
		/// </summary>
		public string student_id
		{
			set{ _student_id=value;}
			get{return _student_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_id
		{
			set{ _course_id=value;}
			get{return _course_id;}
		}
        public int course_score
        {
            set { _course_score = value; }
            get { return _course_score; }
        }
		#endregion Model

	}
}

