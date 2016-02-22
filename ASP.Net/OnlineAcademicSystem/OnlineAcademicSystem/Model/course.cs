using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class course
	{
		public course()
		{}
		#region Model
		private string _course_id;
        private string _classroom_id;
		private string _course_type_id;
		private string _major_id;
		private string _course_name;
		private string _course_time;
        private string _grade_id;
		/// <summary>
		/// 
		/// </summary>
		public string course_id
		{
			set{ _course_id=value;}
			get{return _course_id;}
		}
        public string classroom_id
        {
            set { _classroom_id = value; }
            get { return _classroom_id; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string course_type_id
		{
			set{ _course_type_id=value;}
			get{return _course_type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string major_id
		{
			set{ _major_id=value;}
			get{return _major_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_name
		{
			set{ _course_name=value;}
			get{return _course_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_time
		{
			set{ _course_time=value;}
			get{return _course_time;}
		}
        public string grade_id
        {
            set { _grade_id = value; }
            get { return _grade_id; }
        }
		#endregion Model

	}
}

