using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// teacher_course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class teacher_course
	{
		public teacher_course()
		{}
		#region Model
		private string _teacher_id;
		private string _course_id;
		/// <summary>
		/// 
		/// </summary>
		public string teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string course_id
		{
			set{ _course_id=value;}
			get{return _course_id;}
		}
		#endregion Model

	}
}

